using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Models
{
   public class Employee
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string lastName { get; set; }


        public string Department { get; set; }


        public bool Gender { get; set; }

    
        public DateTime DateOfBirth { get; set; }


        public List<TimeCard> TimeCards { get; set; }


        // new property 
        public string Role { get; set; }


        public DateTime HireTime { get; set; }


        public DateTime? DOB { get; set; }

        [Range(100,100000)]
        public double Salary { get; set; }
    }
}
