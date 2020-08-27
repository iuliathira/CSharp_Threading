using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmployeeAttendanceSystem.Model;

namespace EmployeeAttendanceSystem.Persistence
{
    public class TaskRepo 
    {
        public TaskRepo()
        {
        }

        public List<Model.Task> GetAll()
        {
            using (var db = new SystemContext())
            {
                List<Model.Task> tasks = (from t in db.Tasks
                                    select t).ToList<Model.Task>();
                return tasks;
            }
        }

        public List<Model.Task> GetEmployeeTask(int id)
        {
      using(var db = new SystemContext())
            {
                List<Task> tasks = (from t in db.Tasks
                                    where t.Employee.Id == id
                                    select t).ToList<Task>();
                return tasks;
            }
        }

        public void UpdateTask(Model.Task task)
        {
            using(var db = new SystemContext())
            {
                Model.Task t = db.Tasks.First(i => i.Id == task.Id);
                t.Status = task.Status;
                db.SaveChanges();
            }
        }
        internal object GetTasks(Employee e)
        {
            using (var db = new SystemContext())
            {
                List<Model.Task> tasks = (from task in db.Tasks
                                    where task.Employee.Id == e.Id
                                    select task).ToList<Model.Task>();
                return tasks;
            }
        }

        internal void DeleteTask(int id)
        {
            using (var db = new SystemContext())
            {
                Model.Task task = new Model.Task() { Id = id };
                db.Tasks.Attach(task);
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
        }


        internal void SaveTask(Employee e, String t)
        {
            using (var db = new SystemContext())
            {
                Model.Task task = new Model.Task();
                task.Description = t;
                task.Status = Model.TaskStatus.Open;
                task.Employee = db.Employees.Find(e.Id);
                db.Tasks.Add(task);
                db.SaveChanges();
            }
        }

       
    }
}
