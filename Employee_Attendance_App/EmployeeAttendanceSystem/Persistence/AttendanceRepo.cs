using EmployeeAttendanceSystem.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceSystem.Persistence
{
    public class AttendanceRepo
    {
        public AttendanceRepo()
        {

        }

        public List<Attendance> GetAttendancesForEmployee(Employee e)
        {
            using(var db = new SystemContext())
            {
                List<Attendance> attendances = (from a in db.Attendances
                                                where a.Employee.Id == e.Id
                                                && a.LoginDate <= DateTime.Now
                                                && a.LoginDate >= EntityFunctions.AddDays(a.LoginDate, -7)
                                                select a).ToList<Attendance>();
                return attendances;
            }
        }

        public void SaveAttendance(Employee e, DateTime dateTime)
        {
            
            using (var db = new SystemContext())
            {
                Attendance a = new Attendance();
                a.NoHours = "0";
                a.LoginDate = dateTime;
                a.LogODate = dateTime;
                a.Employee = db.Employees.Find(e.Id);
                db.Attendances.Add(a);
                db.SaveChanges();
            }
        }
        
        internal void UpdateAttendance(Employee currentEmployee, DateTime now)
        {

            using(var db = new SystemContext())
            {
                var attendance = (from a in db.Attendances
                                  where a.Employee.Id == currentEmployee.Id
                                  && a.LoginDate.Day == now.Day && a.LoginDate.Month == now.Month
                                  && a.LoginDate.Year == now.Year
                                  select a).FirstOrDefault<Attendance>();
                attendance.LogODate = now;
                TimeSpan timeSpan = now - attendance.LoginDate;
                String h = timeSpan.ToString();
                attendance.NoHours = h;
                db.SaveChanges();
            }

         
        }
    }
}
