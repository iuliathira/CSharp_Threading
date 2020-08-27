using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1.repository;
using System.Configuration;
using Lab1.model;
using Lab1.tests;
using log4net;
using log4net.Config;
using Lab1.service;
namespace Lab1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Console.WriteLine("Hello!");
            Console.WriteLine(args[0]);
            XmlConfigurator.Configure(new System.IO.FileInfo(args[0]));
            IDictionary<String, string> props = new SortedList<String, String>();
            props.Add("ConnectionString", GetConnectionStringByName("labDB"));
            RepoDbContestant repoDbContestant = new RepoDbContestant(props);
            RepoDbOfficePers repoDbOffice = new RepoDbOfficePers(props);
            RepoDbRace repoDbRace = new RepoDbRace(props);
            RepoDbRegistration repoDbRegistration = new RepoDbRegistration(props);

            ServiceApp service = new ServiceApp(repoDbContestant,repoDbOffice,repoDbRace,repoDbRegistration);
            //repoTests repo1 = new repoTests();
            //repo1.test();

            Login login = new Login();
            login.Service = service;
            Application.Run(login);

        }

        static string GetConnectionStringByName(string name)
        {
            string retVal = null;
            //ConnectionStringSettings settings = ConfigurationManager.Conn
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                retVal = settings.ConnectionString;

            return retVal;
        }
    }
}
