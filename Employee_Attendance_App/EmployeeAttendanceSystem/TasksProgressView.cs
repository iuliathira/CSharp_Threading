using EmployeeAttendanceSystem.Model;
using EmployeeAttendanceSystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EmployeeAttendanceSystem.Utils;

namespace EmployeeAttendanceSystem
{
    public partial class TasksProgressView : Form
    {
        Employee employee;
        CompanyService companyService;
        public TasksProgressView(int id, CompanyService cs)
        {
            InitializeComponent();
            companyService = cs;
            employee = GetEmployee(id);
            loadTable();
        }


        private Employee GetEmployee(int id)
        {
            return companyService.GetEmployeeById(id);
        }

        private void loadTable()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = companyService.GetTasksForEmp(this.employee);
        }
       

        private void deleteTaskBtn_Click(object sender, EventArgs e)
        {
            int idx = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[idx];
            int id = (int)row.Cells[0].Value;
            TaskStatus status = (TaskStatus)row.Cells[2].Value;
            if(status == TaskStatus.ReadyforDemo)
            {
                companyService.DeleteTask(id);
                loadTable();
            }
            else
            {
                MessageBox.Show("You cannot delete this task: it is not ready for demo.");
            }
           
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            companyService.SaveTask(this.employee, descriptionBox.Text);
            loadTable();
        }

        public void UpdateManagerTaskTable()
        {
            loadTable();
        }
    }
}
