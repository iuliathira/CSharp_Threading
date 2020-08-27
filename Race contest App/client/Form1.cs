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
    public partial class Form1 : Form
    {
        private String officePersName;
        private ClientCtrl ctrl;
        private List<Contestant> contestants;
        private List<Race> races = new List<Race>();
        public Form1(ClientCtrl ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        
            ctrl.setForm(this);
            initData();
            ctrl.updateevent += userUpdate;

        }

        public void userUpdate(object sender, UserEventArgs e)
        {
            //races = ctrl.getAllRaces();
            if(e.UserEventType == UserEvent.increaseNoContestants)
            {
                Race r = (Race)e.Data;
                foreach(Race race in races)
                {
                    if (race.EngineCap == r.EngineCap)
                    {
                        race.NoCont--;
                        race.NoRegs++;
                    }
                }



                dataGVRaces.BeginInvoke(new UpdateTableCallback(this.initRacesTable),new Object[] { races });
            }
        }

        public delegate void UpdateTableCallback(List<Race> data);

        private void initRacesTable(List<Race> races)
        {

            dataGVRaces.Rows.Clear();
          
            foreach (Race r in races)
            {
                dataGVRaces.Rows.Add(new string[] { r.id.ToString(), r.EngineCap.ToString(), r.NoCont.ToString(), r.NoRegs.ToString() });
            }
        }

        private void initTableContestants(List<Contestant> conts)
        {
            dataGVCont.Rows.Clear();
            

            foreach (Contestant c in conts)
            {
                dataGVCont.Rows.Add(new string[] { c.id.ToString(), c.Name,c.Team,c.EngineCap.ToString() });
            }
        }
        internal void initData()
        {
            initComboEngine();
            initComboTeam();
            dataGVRaces.ColumnCount = 4;
            dataGVRaces.Columns[0].Name = "ID";
            dataGVRaces.Columns[1].Name = "Engine Capacity";
            dataGVRaces.Columns[2].Name = "Empty Seats";
            dataGVRaces.Columns[3].Name = "Registrations";

            //initRacesTable(ctrl.getAllRaces());
            dataGVCont.ColumnCount = 4;
            dataGVCont.Columns[0].Name = "ID";
            dataGVCont.Columns[1].Name = "Name";
            dataGVCont.Columns[2].Name = "Team";
            dataGVCont.Columns[3].Name = "Engine Capacity";
            //initTableContestants( ctrl.getAllContestants());
            initTables();
        }

        internal void initOnlyTables()
        {

            initRacesTable(ctrl.getAllRaces());
            initTableContestants(ctrl.getAllContestants());
        }

        internal void initTables()
        {
            comboTeam.Text = "all";
            comboEngine.Text = "all";
            
        }


        private void initComboTeam()
        {
            comboTeam.Text = "all";
            comboTeam.Items.Add("all");
            comboTeam.Items.Add("yamaha");
            comboTeam.Items.Add("kawasaki");
            comboTeam.Items.Add("ducati");
            comboTeam.Items.Add("ktm");
            comboTeam.Items.Add("aprilia");
            comboTeam.Items.Add("suzuki");


        }

        private void initComboEngine()
        {
            comboEngine.Text = "all";
            comboEngine.Items.Add("all");
            comboEngine.Items.Add(125);
            comboEngine.Items.Add(150);
            comboEngine.Items.Add(200);
            comboEngine.Items.Add(300);
            comboEngine.Items.Add(400);
            comboEngine.Items.Add(500);
            comboEngine.Items.Add(600);
            comboEngine.Items.Add(700);
            comboEngine.Items.Add(800);
        }

        public string OfficePersName { get => officePersName; set => officePersName = value; }

        internal void setDefaultCombo()
        {
            comboTeam.Text = "all";
            comboEngine.Text = "125";
        }
        
        private void comboTeam_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboTeam.Text.Equals("all"))
            {
                List<Contestant> conts = ctrl.getAllContestants();
                contestants = conts;
                initTableContestants(contestants);
            }
            else
                initTableContestants(ctrl.getContestantsByTeam(comboTeam.Text));
        }

        private void comboEngine_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboEngine.Text.Equals("all"))
            {
                List<Race> rcs = ctrl.getAllRaces();
                races = rcs;
                initRacesTable(rcs);
            }
            else
                initRacesTable(((List<Race>)ctrl.getAllRacesByEngine(int.Parse(comboEngine.Text))));
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            RegistrationWindow registration = new RegistrationWindow(ctrl);
            registration.Form = this;
            registration.Show();
        }

        private void dataGVRaces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
