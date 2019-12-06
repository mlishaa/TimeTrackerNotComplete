namespace TimeTracker.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using TimeTracker.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TimeTracker.Models.TimeTrackerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TimeTracker.Models.TimeTrackerDBContext context)
        {

            // only do this on test data
            // never drop actual data
            context.Employees.RemoveRange(context.Employees);
            context.TimeCards.RemoveRange(context.TimeCards);



            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee()
            {
                FirstName = "Michael",
                lastName = "Lishaa",
                Gender=true,
                DateOfBirth=DateTime.Parse("3/21/1986"),
                Department = "IT",
                Role = "Manager",
                HireTime = DateTime.Now.AddYears(-2),
                Salary=60000,
                TimeCards=new List<TimeCard>()
                {
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-7),
                        MondayHours = 8,
                        TuesdayHours=7,
                        WedesdayHours=6,
                        ThursdayHours=8,
                        FridayHours=9,
                        SaturdayHours=6,
                        SundayHours=0                       
                    }
                }
            });

            employees.Add(new Employee()
            {
                FirstName = "Berri",
                lastName = "Allan",
                Gender = true,

                DateOfBirth = DateTime.Parse("3/20/1980"),
                Department = "CSI Lab",
                Role = "Repsentative",
                HireTime = DateTime.Now.AddYears(-1),
                Salary=10000,
                TimeCards = new List<TimeCard>()
                {
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-14),
                        MondayHours = 10,
                        TuesdayHours=5,
                        WedesdayHours=2,
                        ThursdayHours=1,
                        FridayHours=4,
                        SaturdayHours=8,
                        SundayHours=0
                    },
                     new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-14),
                        MondayHours = 8,
                        TuesdayHours=0,
                        WedesdayHours=1,
                        ThursdayHours=1,
                        FridayHours=0,
                        SaturdayHours=6,
                        SundayHours=3
                    }
                }
            });
            employees.Add(new Employee()
            {
                FirstName = "Oliver",
                lastName = "Queen",
                Gender = false,
                DateOfBirth = DateTime.Parse("11/21/1970"),
                Department = "Managament",
                Role = "Flash",
                HireTime = DateTime.Now.AddYears(-1),
                DOB = DateTime.Now.AddYears(-30),
                Salary=50000,
                TimeCards = new List<TimeCard>()
                {
                    new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-10),
                        MondayHours = 3,
                        TuesdayHours=3,
                        WedesdayHours=3,
                        ThursdayHours=0,
                        FridayHours=2,
                        SaturdayHours=3,
                        SundayHours=0
                    },
                     new TimeCard()
                    {
                        SubmissionDate = DateTime.Now.AddDays(-5),
                        MondayHours = 3,
                        TuesdayHours=0,
                        WedesdayHours=2,
                        ThursdayHours=2,
                        FridayHours=0,
                        SaturdayHours=0,
                        SundayHours=9
                    }
                }
            });

            context.Employees.AddRange(employees);
            base.Seed(context);
        }
    }
}
