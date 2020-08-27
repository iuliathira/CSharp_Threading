using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using services;

using networking;
using client.controller;
namespace client
{
    static class StartClient
    {
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IServer server = new ServerProxy("127.0.0.1", 55555);
            ClientCtrl ctrl = new ClientCtrl(server);
            Login loginWindow = new Login(ctrl);
            Application.Run(loginWindow);
           
        }
    }
}
