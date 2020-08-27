using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using EmployeeAttendanceSystem.Model;
using EmployeeAttendanceSystem.Persistence;
using EmployeeAttendanceSystem.Services;
using System.Data.Common;
using System.Data.OracleClient;

namespace EmployeeAttendanceSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Singleton pattern used for class RepoCompany
            // RepoCompany repoCompany = new RepoCompany();
            TaskRepo taskRepo = new TaskRepo();
            CompanyService companyService = new CompanyService(RepoCompany.Instance, taskRepo);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginView(companyService));
        
            }
    }
}
