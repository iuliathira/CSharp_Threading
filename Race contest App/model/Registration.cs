using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace race.model
{
    public class Registration : HasID<int>
    {
        private int regID;
        private int opID;
        private int contID;
        private int raceID;

        public Registration(int regID, int opID, int contID, int raceID)
        {
            this.regID = regID;
            this.opID = opID;
            this.contID = contID;
            this.raceID = raceID;
        }

        public int id
        {
            get { return regID; }
            set { regID = value; }
        }

        public int OpID
        {
            get { return opID; }
            set { opID = value; }

        }

        public int ContID
        {
            get { return contID; }
            set { contID = value; }

        }

        public int RaceID
        {
            get { return raceID; }
            set { raceID = value; }

        }

        public override string ToString()
        {
            return "[" + this.regID + ", " + this.opID + ", " +
                this.raceID + ", " + this.contID + "]";
        }
    }
}
