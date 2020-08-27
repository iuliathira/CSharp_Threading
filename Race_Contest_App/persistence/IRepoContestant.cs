using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using race.model;


namespace race.repository
{
    public interface IRepoContestant : ICrudRepository<int, Contestant>
    {
        IEnumerable<Contestant> getRacesByTeam(string team);
    }
}
