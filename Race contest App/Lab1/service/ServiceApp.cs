using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.repository;
using Lab1.model;

namespace Lab1.service
{
    class ServiceApp
    {
        RepoDbContestant repoC;
        RepoDbOfficePers repoOp;
        RepoDbRace repoR;
        RepoDbRegistration repoReg;

        public ServiceApp(RepoDbContestant repoC, RepoDbOfficePers repoOp, RepoDbRace repoR, RepoDbRegistration repoReg)
        {
            this.repoC = repoC;
            this.repoOp = repoOp;
            this.repoR = repoR;
            this.repoReg = repoReg;
        }

        public List<Race> getAllRaces() => (List<Race>)repoR.findAll();

        public List<Contestant> getAllContestants() => (List<Contestant>)repoC.findAll();


        public IEnumerable<Contestant> getAllContestantsByTeam(String team)
        {

            return repoC.getRacesByTeam(team);
        }

        public IEnumerable<Race> getAllRacesByEngine(int engine)
        {
            return repoR.getRacesByEngine(engine);
        }           

        public OfficePers validateCredentials(String username,String password)
        {
            OfficePers op = repoOp.findByUserPass(username, password);
            return op;
        }

        public void registerClient(String name,String team,int engine)
        {
            repoC.save(new Contestant(name,team,engine));
            Race r = repoR.getByTeam(engine);
            if (r.NoCont != 0)
            {
                repoR.update(new Race(r.id, r.EngineCap, r.NoCont - 1, r.NoRegs + 1));
            }
        }

    }
}
