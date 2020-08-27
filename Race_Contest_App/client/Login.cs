using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using client.controller;
using race.model;


namespace client
{
    public partial class Login : Form
    {

        private ClientCtrl ctrl;
        public Login(ClientCtrl ct)
        {
            InitializeComponent();
            this.ctrl = ct;
        }


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
                    try
                    {
                        ctrl.login(username, password);
                        Form1 contextForm = new Form1(ctrl);
                        contextForm.Show();
                        contextForm.FormClosed += new FormClosedEventHandler(delegate { Close(); });
                        //ctrl.setUsername(username);
                        this.Hide();
                    }catch(Exception ex)
                    {
                        MessageBox.Show("Login error: " + ex.Message);
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
