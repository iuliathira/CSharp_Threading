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
using EmployeeAttendanceSystem.Utils;
namespace EmployeeAttendanceSystem
{
    public partial class ManagerView : Form, Observer<Event>
    {
        CompanyService CompanyService;
        public ManagerView(CompanyService c)
        {
            InitializeComponent();
            this.CompanyService = c;
            this.UpdatePresentEmployees(new LoginEvent());
        }
      
        private void manageContsButton_Click(object sender, EventArgs e)
        {
            UsersManagementView view = new UsersManagementView(CompanyService);
            view.Show();
        }

        private TasksProgressView progressView;

        private void viewTasksBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int idx = loggedUsersTable.CurrentCell.RowIndex;
                DataGridViewRow row = loggedUsersTable.Rows[idx];
                int id = (int)row.Cells[4].Value;
                Console.WriteLine(id);
                progressView = new TasksProgressView(id, CompanyService);
                progressView.Show();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("No employee selected!");
            }
        }

        public void UpdateTaskTable(Event e)
        {
            
        }

        public void UpdatePresentEmployees(Event e)
        {
            loggedUsersTable.Columns.Clear();
            loggedUsersTable.DataSource = CompanyService.GetLoggedEmployees();
        }

        public void EmployeeLogout(Observer<Event> o)
        {
            CompanyService.removeObserver(o);
            UpdatePresentEmployees(new LogoutEvent());
        }

        public void ManagerLogout(Observer<Event> o)
        {

        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            CompanyService.notifyLogOutManager(this);
            this.Close();
        }

        public void UpdateManagerTaskTable()
        {
            if (progressView != null)
                progressView.UpdateManagerTaskTable();

        }
    }
}
