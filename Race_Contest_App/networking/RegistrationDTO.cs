using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networking
{
    [Serializable]
    public class RegistrationDTO
    {
        ContestantDTO contestant;
        RaceDTO race;

        public RegistrationDTO(ContestantDTO c, RaceDTO r)
        {
            this.contestant = c;
            this.race = r;
        }

        public ContestantDTO Contestant
        {
            get
            {
                return this.contestant;
            }
        }

        public  RaceDTO Race
        {
            get
            {
                return this.race;
            }
        }
    }
}
