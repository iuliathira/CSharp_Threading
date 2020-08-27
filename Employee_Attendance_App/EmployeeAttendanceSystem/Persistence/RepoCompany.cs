using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeAttendanceSystem.Model;
namespace EmployeeAttendanceSystem.Persistence
{
    public class RepoCompany
    {
        static Manager manager = new Manager();
        static Company company = new Company();
        private static RepoCompany instance = null;

        private RepoCompany() { }

        public static RepoCompany Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RepoCompany();
                    manager.Id = 1;
                    manager.FirstName = "Julie";
                    manager.LastName = "Smith";
                    manager.Age = 29;
                    manager.Username = "juliesmith";
                    manager.Password = "managerpass";
                    manager.Position = "manager";
                }
                return instance;
            }
        }
        
      

        internal User GetByUsernameAndPass(string username, string password)
        {
            if (username == manager.Username && password == manager.Password)
                return manager;
            using(var db = new SystemContext())
            {
                var employee = (from e in db.Employees
                               where e.Password == password && e.Username == username
                               select e).FirstOrDefault<Employee>();
                if(employee != null)
                {
                    employee.Logged = "yes";
                    db.SaveChanges();
                }
                return employee;
            }
            //return null;
        }
       
        internal List<Employee> GetLoggedUsers()
        {
            using (var db = new SystemContext())
            {
                List<Employee> employees = (from emp in db.Employees
                                    where emp.Logged.Equals("yes")
                                    select emp).ToList<Employee>();
                return employees;
            }

        }

        internal Employee GetEmployeeById(int id)
        {
            using (var db = new SystemContext())
            {
                var employee = (from e in db.Employees
                                where e.Id == id
                                select e).FirstOrDefault<Employee>();
                Console.WriteLine("Se returneaza angajatul:" + employee.FirstName + " " + employee.LastName + " " + employee.Username + " " + employee.Password);
                return employee;
            }
        }

        internal void UpdateAccount(int id, string username, string password, string position)
        {
            using (var db = new SystemContext())
            {
                var employee = (from e in db.Employees
                                where e.Id == id
                                select e).FirstOrDefault<Employee>();
                employee.Username = username;
                employee.Password = password;
                employee.Position = position;
                db.SaveChanges();
            }
        }

        internal void DeleteAccount(int id)
        {
            using (var db = new SystemContext())
            {

                db.Attendances.RemoveRange(db.Attendances.Where(x => x.Employee.Id == id));
                
                Employee employee = new Employee() { Id = id };
                db.Employees.Attach(employee);
                db.Employees.Remove(employee);
                db.SaveChanges();
            }
        }
      
        internal void LogIn(int id)
        {
            using (var db = new SystemContext())
            {
                Employee e = db.Employees.First(i => i.Id == id);
                e.Logged = "yes";
                db.SaveChanges();
            }
        }


        internal void LogOut(int id)
        {
            using (var db = new SystemContext())
            {
                Employee e = db.Employees.First(i => i.Id == id);
                e.Logged = "no";
                db.SaveChanges();
            }
        }
        
        internal Employee GetEmployee(string username, string password)
        {
            Console.WriteLine("Repo: username= " + username + ", parola: " + password);
            using (var db = new SystemContext())
            {
                var employee = (from e in db.Employees
                                where e.Password == password && e.Username == username
                                select e).FirstOrDefault<Employee>();
                Console.WriteLine("Se returneaza angajatul:" + employee.FirstName + " " + employee.LastName + " " + employee.Username + " " + employee.Password);
                return employee;
            }
        }
        
        internal List<User> GetAllUsers()
        {
            using(var db = new SystemContext())
            {
                List<User> users = (from user in db.Employees
                                    select user).ToList<User>();
                Console.WriteLine("Len:: " + users.Count);
                return users; 
            }
        }

        internal void SaveAccount(Employee employee)
        {
            using(var db = new SystemContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }
    }
}
