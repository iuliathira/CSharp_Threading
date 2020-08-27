using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace race.model
{
    public class Contestant:HasID<int>
    {
        private int contestantID;
        private string name;
        private string team;
        private int engineCap;

        public Contestant(int id,string name, string team, int engCap)
        {
            this.contestantID = id;
            this.name = name;
            this.team = team;
            this.engineCap = engCap;

       }

        public Contestant(string name, string team, int engCap)
        {
            
            this.name = name;
            this.team = team;
            this.engineCap = engCap;

        }

        public int id {
            get { return contestantID; }
            set { contestantID = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Team
        {
            get { return team; }
            set { team = value; }
        }

        public int EngineCap
        {
            get { return engineCap; }
            set { engineCap = value; }
        }

        public override string ToString()
        {
            return "[" + contestantID.ToString() + ", " + name + ", " +
            team + ", " + engineCap.ToString();
        }
    }
}
