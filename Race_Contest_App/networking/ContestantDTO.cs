using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networking
{
    [Serializable]
    public class ContestantDTO
    {
        private string name;
        private string team;
        private int engine;

        public ContestantDTO(string name, string team, int engine)
        {
            this.name = name;
            this.team = team;
            this.engine = engine;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Team
        {
            get
            {
                return this.team;
            }
        }

        public int Engine
        {
            get
            {
                return this.engine;
            }
        }


    }
}
