using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using race.model;

namespace networking
{
    
    public class DTOUtils
    {
        public static OfficePers getFromDTO(OfficePersonDTO officePersonDTO)
        {
            String username = officePersonDTO.Username;
            String pass = officePersonDTO.Password;
            return new OfficePers(username, pass);
        }

        public static OfficePersonDTO getDTO(OfficePers user)
        {
            String uname = user.Username;
            String pass = user.Password;
            return new OfficePersonDTO(uname, pass);
        }

        public static Contestant getFromDTO(ContestantDTO contestantDTO)
        {
            String name = contestantDTO.Name;
            String team = contestantDTO.Team;
            int eng = contestantDTO.Engine;
            return new Contestant(name, team, eng);
        }

        public static ContestantDTO getDTO(Contestant c)
        {
            String name = c.Name;
            String team = c.Team;
            int eng = c.EngineCap;
            return new ContestantDTO(name, team, eng);
        }

        public static Race getFromDTO(RaceDTO r)
        {
            int engine = r.Engine;
            int cont = r.NoCont;
            int regs = r.NoRegs;
            return new Race(r.RaceID, engine, cont, regs);
        }

        public static RaceDTO getDTO(Race r)
        {
            int engine = r.EngineCap;
            int noCont = r.NoCont;
            int noRegs = r.NoRegs;
            return new RaceDTO(r.id, engine, noCont, noRegs);
        }
    }
}
