using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EmployeeAttendanceSystem.Model;
using EmployeeAttendanceSystem.Services;
using EmployeeAttendanceSystem.Utils;


namespace EmployeeAttendanceSystem
{
    public partial class EmployeeView : Form, Observer<Event>
    {
        EmployeeService service;
        Employee currentEmployee;



        public EmployeeView(EmployeeService srv, User e)
        {
            InitializeComponent();
            this.service = srv;
            this.currentEmployee = (Employee)e;
            nameLabel.Text = "Welcome, : " + e.Username;
            PopulateTaskTable(srv.GetTasksForEmployee(currentEmployee.Id));
            service.Login(currentEmployee, DateTime.Now);
        }

        private void PopulateTaskTable(List<Task> tasks)
        {
            tasksTable.Columns.Clear();
            tasksTable.DataSource = tasks;
        }

      
        private void updateTaskBtn_Click(object sender, EventArgs e)
        {
            int idx = tasksTable.CurrentCell.RowIndex;
            DataGridViewRow row = tasksTable.Rows[idx];
            int id =(int) row.Cells[0].Value;
            string desc = row.Cells[1].Value.ToString();
            TaskStatus status =(TaskStatus)row.Cells[2].Value;
            service.UpdateTask(id, desc, status);
            PopulateTaskTable(service.GetTasksForEmployee(currentEmployee.Id));

        }

        private void viewAttendanceBtn_Click(object sender, EventArgs e)
        {
            AttendanceView attendanceView = new AttendanceView(service, currentEmployee);
            attendanceView.Show();
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            
            service.Logout(currentEmployee, DateTime.Now);
            service.notifyLogOutEmployee(new LogoutEvent(),this);
            this.Close();
        }

        public void UpdateTaskTable(Event e)
        {
            if(e is TaskEvent)
            {
                PopulateTaskTable(service.GetTasksForEmployee(currentEmployee.Id));
            }
        }

        public void UpdatePresentEmployees(Event e)
        {
            
        }

        public void EmployeeLogout(Observer<Event> o)
        {
        }

        public void ManagerLogout(Observer<Event> o)
        {
            service.removeObserver(o);
        }

        public void UpdateManagerTaskTable()
        {
        }
    }
}
