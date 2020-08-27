using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Model
{
    [Table("Tasks")]
    public class Task
    {
        [Key()]
        public int Id { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public Employee Employee { get; set; }
    }

    public enum TaskStatus { Open, InProgress, ReadyForTesting, ReadyforDemo, Closed }
}
