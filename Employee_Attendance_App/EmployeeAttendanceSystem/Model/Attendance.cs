using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeAttendanceSystem.Model
{
    [Table("Attendances")]
    public class Attendance
    {
        [Key()]
        public int Id { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogODate { get; set; }

        public String NoHours { get; set; }
        public Employee Employee { get; set; }

       
    }
}
