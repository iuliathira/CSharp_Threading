using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EmployeeAttendanceSystem.Model
{
    [Table("Employees")]
    public class Employee:User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string JobPosition { get; set; }

        public override string ToString()
        {
            return this.Id + " " + this.Username + " " + this.Password + " " + this.Position +
                this.Logged + " " + this.FirstName + " " + this.LastName + " " + this.Age + " " + this.JobPosition;
        }
      



    }
}
