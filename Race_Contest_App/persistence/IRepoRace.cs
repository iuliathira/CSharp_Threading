using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using race.model;
namespace race.repository
{
    public interface IRepoRace:ICrudRepository<int,Race>
    {
        IEnumerable<Race> getRacesByEngine(int engineCap);
        void update(Race r);
        Race getByTeam(int engine);

    }
}
