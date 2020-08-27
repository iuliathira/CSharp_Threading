using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services;
using race.model;

namespace client.controller
{
    public class ClientCtrl : IClient 
    {
        public event EventHandler<UserEventArgs> updateevent;
        private readonly IServer server;
        private OfficePers currentUser;
        private Form1 parentForm;

        public ClientCtrl(IServer srv)
        {
            this.server = srv;
            currentUser = null;
        }

       
        public void setForm(Form1 f)
        {
            this.parentForm = f;
        }


        //private OfficePers currentUser;

        public void login(String username, String pass)
        {
            OfficePers user = new OfficePers(username, pass);
            server.login(user, this);
            Console.WriteLine("Login succeeded...");
            this.currentUser = user;
            Console.WriteLine("Current user {0}", user);
            
        }

        public void logOut()
        {
            server.logout(currentUser, this);
            currentUser = null;
        }

        public virtual void OnUserEvent(UserEventArgs e)
        {
            Console.WriteLine("Client controller - Update Event called");

            if (updateevent == null)
                return;
            Console.WriteLine("Client controller - Update Event NOT NULL");

            updateevent(this, e);
            Console.WriteLine("Update Event called");
        }

        public void increaseNoContestants(Race race)
        {
            Console.WriteLine("Client controller increse no contestants");
            UserEventArgs userEvent = new UserEventArgs(UserEvent.increaseNoContestants, race);
            OnUserEvent(userEvent);
        }

        internal List<Contestant> getAllContestants()
        {
            return server.getAllContestants();
        }

        internal List<Contestant> getContestantsByTeam(string text)
        {
            return server.getContestantsByTeam(text);
        }

        internal void registerContestant(string name, string team, int engine)
        {
            server.addContestant(name, engine, team,currentUser.Username);
        }

        internal List<Race> getAllRaces()
        {
            return server.getAllRaces();
        }

        internal List<Race> getAllRacesByEngine(int v)
        {
            return server.getRacesByEngine(v);
        }
    }
}
