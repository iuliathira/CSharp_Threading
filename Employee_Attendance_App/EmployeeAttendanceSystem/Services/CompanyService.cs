using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeAttendanceSystem.Persistence;
using EmployeeAttendanceSystem.Model;
using EmployeeAttendanceSystem.Utils;
namespace EmployeeAttendanceSystem.Services
{
    public class CompanyService : MarshalByRefObject, Observable<Event> 
    {

        private RepoCompany RepoCompany;
        private TaskRepo TaskRepo;
        List<Observer<Event>> Observers = new List<Observer<Event>>();

        public CompanyService(RepoCompany repo, TaskRepo repoT)
        {
            this.RepoCompany = repo;
            this.TaskRepo = repoT;
        }

        internal Employee GetEmployeeByUser(String username, String password)
        {
            return RepoCompany.GetEmployee(username, password);
        }

        internal Employee GetEmployeeById(int id)
        {
            return RepoCompany.GetEmployeeById(id);
        }

        internal object GetTasksForEmp(Employee e)
        {
            return TaskRepo.GetTasks(e);
            //return RepoCompany.GetTasks(e);
        }

        internal List<Employee> GetLoggedEmployees()
        {
            return RepoCompany.GetLoggedUsers();
        }

        internal User ValidateCredentials(string username, string password)
        {
            User user = RepoCompany.GetByUsernameAndPass(username, password);
            if (user == null)
                throw new ServiceException("No user found!");
            else
            {
                return user;
            }
        }

        internal void DeleteTask(int id)
        {
            TaskRepo.DeleteTask(id);
            //RepoCompany.DeleteTask(id);
            notifyObservers(new TaskEvent());
        }

        internal void SaveTask(Employee e, string text)
        {

            TaskRepo.SaveTask(e, text);
            //RepoCompany.SaveTask(e, text);
            notifyObservers(new TaskEvent());
        }
        
        internal List<User> GetAllUsers()
        {
            return RepoCompany.GetAllUsers();
        }
        
        internal void DeleteAccount(int id)
        {
            RepoCompany.DeleteAccount(id);
        }

        internal void UpdateAccount(int id, string username, string password, string position)
        {
            RepoCompany.UpdateAccount(id, username, password, position);
        }

        internal void SaveAccount(Employee employee)
        {
            RepoCompany.SaveAccount(employee);
        }

       
        public void addObserver(Observer<Event> e)
        {
            this.Observers.Add(e);
            Console.WriteLine("Adding observer to the list");
        }

        public void removeObserver(Observer<Event> e)
        {
            this.Observers.Remove(e);
        }

        public void notifyObservers(Event t)
        {
            Console.WriteLine("notifying observers...");
            foreach(Observer<Event> obs in this.Observers)
            {
                obs.UpdateTaskTable(new TaskEvent());
            }

        }

        public void notifyLogIn(Event t)
        {
            foreach (Observer<Event> obs in this.Observers)
            {
                obs.UpdatePresentEmployees(new LoginEvent());
            }
        }

        public void notifyLogOutEmployee(Event t, Observer<Event> obs)
        {
           
        }

        public void notifyLogOutManager(Observer<Event> obs)
        {
            foreach (Observer<Event> o in this.Observers)
            {
                o.ManagerLogout(obs);
            }
        }

        public void notifyManagerTasks()
        {
        }
    }
}
