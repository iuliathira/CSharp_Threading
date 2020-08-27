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
    public partial class RegistrationWindow : Form
    {
        Form1 form;

        ClientCtrl ctrl;
        public RegistrationWindow(ClientCtrl ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            initComboBoxes();
            
        }

        private void initComboBoxes()
        {
            teamText.Items.Add("yamaha");
            teamText.Items.Add("ktm");
            teamText.Items.Add("ducati");
            teamText.Items.Add("kawasaki");
            teamText.Items.Add("aprilia");
            teamText.Items.Add("suzuki");

            engineText.Items.Add(125);
            engineText.Items.Add(150);
            engineText.Items.Add(200);
            engineText.Items.Add(300);
            engineText.Items.Add(400);
            engineText.Items.Add(500);
            engineText.Items.Add(600);
            engineText.Items.Add(700);
            engineText.Items.Add(800);



        }

        public Form1 Form { get => form; set => form = value; }

        private void RegistrationWindow_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = contText.Text;
            String team = teamText.Text;
            int engine = 0;
            
           // try
            //{
                engine = int.Parse(engineText.Text);
                if (name == "" || team == "" || engine == 0)
                {
                    MessageBox.Show("Please complete all fields!");
                }
                else
                {
                    ctrl.registerContestant(name, team, engine);
                    //form.initOnlyTables();
                }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Engine must be an integer: " + ex.Message);
            //}
            

        }
    }
}
