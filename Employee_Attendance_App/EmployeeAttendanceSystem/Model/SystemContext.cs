using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace EmployeeAttendanceSystem.Model
{
    public class SystemContext : DbContext
    {
        public SystemContext() : base("name=DefaultConnection")
        {
            
        }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
