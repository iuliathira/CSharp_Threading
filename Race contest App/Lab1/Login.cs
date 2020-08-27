using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab1.model;
using Lab1.service;
namespace Lab1
{
    public partial class Login : Form
    {

        private ServiceApp service;
        public Login()
        {
            InitializeComponent();   
        }

        internal ServiceApp Service { get => service; set => service = value; }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                String username = usernameText.Text;
                String password = passwordText.Text;
                
                if(username == "" || password == "")
                {
                    MessageBox.Show("Please complete all fields!");
                }
                else
                {
                    OfficePers op = service.validateCredentials(username, password);
                    if ( op != null)
                    {
                        //this.Hide();
                        Form1 contextForm = new Form1();
                        contextForm.OfficePersName = op.Name;
                        contextForm.Service = service;
                        contextForm.Show();
                        contextForm.initData();

                    }
                    else
                    {
                        MessageBox.Show("Username or password incorrect");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }

                    }
    }
}
