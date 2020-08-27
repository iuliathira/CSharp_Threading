using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    using race.model;
    public interface IServer
    {
        void login(OfficePers user, IClient client);
        void logout(OfficePers user, IClient client);

        List<Race> getAllRaces();
        List<Contestant> getAllContestants();
        List<Contestant> getContestantsByTeam(String team);
        List<Race> getRacesByEngine(int engine);
        void addContestant(String name, int engine, String team, String username);
    }
}
