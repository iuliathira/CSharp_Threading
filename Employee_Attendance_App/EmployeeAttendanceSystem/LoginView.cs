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
using EmployeeAttendanceSystem.Persistence;
using EmployeeAttendanceSystem.Model;

namespace EmployeeAttendanceSystem
{
    public partial class LoginView : Form
    {
        CompanyService companyService;
        EmployeeService employeeService;
     
        ManagerView managerView = null;
        Manager manager = null;
        public LoginView(CompanyService service)
        {
            InitializeComponent();
            this.companyService = service;            
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameField.Text;
            string password = passwordField.Text;
            if(employeeService == null)
            {
                TaskRepo taskRepo = new TaskRepo();
                AttendanceRepo attendanceRepo = new AttendanceRepo();
                //RepoCompany repoCompany = new RepoCompany();
                employeeService = new EmployeeService(taskRepo, attendanceRepo, RepoCompany.Instance);
            }
            try
            {
                User user = companyService.ValidateCredentials(username, password);
                if (user.Position.Equals("employee"))
                {
                    Employee employee = companyService.GetEmployeeByUser(username, password);
                    
                    EmployeeView employeeView = new EmployeeView(employeeService,user);
                    companyService.addObserver(employeeView);

                    employeeView.Show();
                  
                }
                if (user.Position.Equals("manager"))
                {
                    managerView = new ManagerView(companyService);
                    manager = new Manager();
                    employeeService.addObserver(managerView);
      
                    managerView.Show();
                }

            }
            catch(ServiceException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
