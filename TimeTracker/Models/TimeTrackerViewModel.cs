using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Models
{
    // 1- make class public
   public  class TimeTrackerViewModel
    {
        // access my data via dbcontext object
        TimeTrackerDBContext context = new TimeTrackerDBContext();


        // get all the employees
        public List<Employee> GetALlEmployees()
        {
            // i can have multiple includes
            return context.Employees.Include("TimeCards").ToList();
            // include allows me to get foriegn data [ known as Eager loading ]
        }
        // without time card
        public List<Employee> GetALlEmployeesData()
        {
            // i can have multiple includes
            return context.Employees.ToList();

        }

        // get TimeCard for an employee
        // i can return a single or default result if i'm sure it will 
        public List<TimeCard> GetTimeCardsPerEmployee(int ID)
        {
            return (from e in context.Employees
                    where e.ID == ID
                    select e.TimeCards).SingleOrDefault();
        }

        public void DeleteANEmployee(int ID)
        {

            Employee tobeDeleted = (from emp in context.Employees
                                    where emp.ID == ID
                                    select emp).SingleOrDefault();

            List<TimeCard> cardsToBEDeleted = (from emp in context.Employees
                                               where emp.ID == tobeDeleted.ID
                                               select emp.TimeCards).SingleOrDefault();
            context.TimeCards.RemoveRange(cardsToBEDeleted);
            context.Employees.Remove(tobeDeleted);
            context.SaveChanges();
           
        }

        public void AddEmployee(Employee emp)
        {
            context.Employees.Add(emp);
        }

        public List<Employee> SearchByLastName(string last)
        {
            return (from e in context.Employees.Include("TimeCards")
                    where e.lastName.Contains(last)
                    select e).ToList();

        }

    }
}
