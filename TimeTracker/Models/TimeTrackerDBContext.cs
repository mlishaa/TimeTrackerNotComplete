using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// 1 add name space for entity framework
using System.Data.Entity;
namespace TimeTracker.Models
{

    // 2- inherit from dbcontext
    class TimeTrackerDBContext : DbContext
    {
        // get the DB sets from DB tables
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeCard>  TimeCards { get; set; }

    }
}
