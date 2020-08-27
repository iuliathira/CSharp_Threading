using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services;
using race.repository;
using race.model;


namespace server
{
    public class ServerImpl : IServer
    {
        private IRepoContestant contRepo;
        private IRepoRace raceRepo;
        private IOfficePers userRepo;
        private RepoDbRegistration regRepo;
        private readonly IDictionary<String, IClient> loggedClients;

        public ServerImpl(IRepoContestant repoContestant, IRepoRace repoRace, IOfficePers officePers, RepoDbRegistration reg) 
        {
            this.contRepo = repoContestant;
            this.raceRepo = repoRace;
            this.userRepo = officePers;
            this.regRepo = reg;
            loggedClients = new Dictionary<String, IClient>();
        }

        public void addContestant(string name, int engine, string team, string username)
        {
            Contestant addedContestant = new Contestant(name, team, engine);
            contRepo.save(addedContestant);
            Race r = raceRepo.getByTeam(engine);
            raceRepo.update(new Race(r.id, r.EngineCap, r.NoCont - 1, r.NoRegs + 1));
            Notify(r, username);
        }

        public List<Contestant> getAllContestants()
        {
            return contRepo.findAll().ToList();
        }

        public List<Race> getAllRaces()
        {
            return raceRepo.findAll().ToList();
        }

        public List<Contestant> getContestantsByTeam(string team)
        {
            List<Contestant> contestants = new List<Contestant>();
            foreach(Contestant c in contRepo.findAll())
            {
                if (c.Team.Equals(team))
                {
                    contestants.Add(c);
                }
            }
            return contestants;
        }

        public List<Race> getRacesByEngine(int engine)
        {
            List<Race> races = new List<Race>();
            foreach(Race r in raceRepo.findAll())
            {
                if (r.EngineCap == engine)
                {
                    races.Add(r);
                }
            }
            return races;
        }

        public void login(OfficePers user, IClient client)
        {
            OfficePers userOK = userRepo.findByUserPass(user.Username, user.Password);
            if (userOK != null)
            {
                if (loggedClients.ContainsKey(user.Username))
                    throw new RaceException("User already logged in.");
                loggedClients[user.Username] = client;
                //notifyLogIn(user);
            }
            else
                throw new RaceException("Authentication failed.");
        }


        public void logout(OfficePers user, IClient client)
        {
            IClient localClient = loggedClients[user.Username];
            if (localClient == null)
                throw new RaceException("User: " + user.Username + " is not logged in.");
            loggedClients.Remove(user.Username);
            //notifyLogOut(user);
        }
        private void Notify(Race r, string username)
        {
            foreach(String user in loggedClients.Keys)
            {
                loggedClients[user].increaseNoContestants(r);
            }
        } 

    }
}
