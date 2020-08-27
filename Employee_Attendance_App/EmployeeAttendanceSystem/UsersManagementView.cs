using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeAttendanceSystem.Services;
using EmployeeAttendanceSystem.Model;

namespace EmployeeAttendanceSystem
{
    public partial class UsersManagementView : Form
    {
        private CompanyService service;
        public UsersManagementView(CompanyService c)
        {
            InitializeComponent();
            this.service = c;
            LoadUsers();
        }

        private void LoadUsers()
        {
            List<User> users = service.GetAllUsers();
            usersTable.Columns.Clear();
            usersTable.DataSource = users;

        }

        private void saveAccountButton_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            string fname = firstnameField.Text;
            string lname = lastnameField.Text;
            int age =  int.Parse(ageField.Text);
            string job = jobField.Text;
            string username = usernameField.Text;
            string pass = passwordField.Text;
            string position = positionField.Text;

            employee.FirstName = fname;
            employee.LastName = lname;
            employee.Age = age;
            employee.JobPosition = job;
            employee.Username = username;
            employee.Password = pass;
            employee.Position = position;

            service.SaveAccount(employee);
            LoadUsers();
        }

        void deleteBtn_Click(object sender, EventArgs e)
        {
            int idx = usersTable.CurrentCell.RowIndex;
            DataGridViewRow row = usersTable.Rows[idx];
            int id = (int)row.Cells[0].Value;
            service.DeleteAccount(id);
            LoadUsers();

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            int idx = usersTable.CurrentCell.RowIndex;
            DataGridViewRow row = usersTable.Rows[idx];
            int id = (int)row.Cells[0].Value;
            service.UpdateAccount(id, row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString());
            LoadUsers();
        }
    }
}
