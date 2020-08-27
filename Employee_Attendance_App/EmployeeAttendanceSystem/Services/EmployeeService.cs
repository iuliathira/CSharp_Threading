using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeAttendanceSystem.Model;
using EmployeeAttendanceSystem.Persistence;
using EmployeeAttendanceSystem.Utils;

namespace EmployeeAttendanceSystem.Services
{
    public class EmployeeService : MarshalByRefObject, Observable<Event>
    {
        private TaskRepo TaskRepo;
        private AttendanceRepo AttendanceRepo;
        private RepoCompany RepoCompany;
        List<Observer<Event>> observers = new List<Observer<Event>>();

        public EmployeeService(TaskRepo taskRepo, AttendanceRepo attendanceRepo, RepoCompany rc)
        {
            TaskRepo = taskRepo;
            AttendanceRepo = attendanceRepo;
            RepoCompany = rc;
        }

        public void addObserver(Observer<Event> e)
        {
            observers.Add(e);
        }

        public List<Task> GetTasksForEmployee(int employeeID)
        {
            return TaskRepo.GetEmployeeTask(employeeID);
        }

        public void notifyLogIn(Event t)
        {
            foreach(Observer<Event> obs in observers)
            {
                obs.UpdatePresentEmployees(new LoginEvent());
            }
        }
        /*
        public void notifyLogOut(Event t, Observer<Event> obs)
        {
            foreach (Observer<Event> o in observers)
            {
              //  o.LogOut(obs);
            }
        }*/

        public void notifyLogOutEmployee(Event t, Observer<Event> obs)
        {
            foreach(Observer<Event> observer in this.observers)
            {
                observer.EmployeeLogout(obs);
            }
        }

        public void notifyLogOutManager(Observer<Event> obs)
        {
            throw new NotImplementedException();
        }

        public void notifyManagerTasks()
        {
            foreach (Observer<Event> observer in this.observers)
            {
                observer.UpdateManagerTaskTable();
            }
        }

        public void removeObserver(Observer<Event> e)
        {
            this.observers.Remove(e);
        }

        public void UpdateTask(int id, string desc, TaskStatus status)
        {
            Task t = new Task();
            t.Id = id;
            t.Description = desc;
            t.Status = status;
            TaskRepo.UpdateTask(t);
            this.notifyManagerTasks();
        }

        internal List<Attendance> GetAttendancesForEmployee(Employee e)
        {
            return AttendanceRepo.GetAttendancesForEmployee(e);
        }

        internal void Login(Employee currentEmployee, DateTime now)
        {
            AttendanceRepo.SaveAttendance(currentEmployee, now);
            this.notifyLogIn(new LoginEvent());
        }

        internal void Logout(Employee currentEmployee, DateTime now)
        {
           AttendanceRepo.UpdateAttendance(currentEmployee, DateTime.Now);
           RepoCompany.LogOut(currentEmployee.Id);
        }


    }
}
