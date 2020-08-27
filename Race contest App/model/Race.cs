using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace race.model
{
    public class Race: HasID<int>
    {
        private int raceID;
        private int engineCap;
        private int noCont;
        private int noRegs;
        private int engine;

        public Race(int engine)
        {
            this.engine = engine;
        }

        public Race(int raceID, int engineCap, int noCont, int noRegs)
        {
            this.raceID = raceID;
            this.engineCap = engineCap;
            this.noCont = noCont;
            this.noRegs = noRegs;
        }

        public int id
        {
            get { return raceID; }
            set { raceID = value; }

        }

        public int EngineCap
        {
            get { return engineCap; }
            set { engineCap = value; }

        }

        public int NoCont
        {
            get { return noCont; }
            set { noCont = value; }

        }

        public int NoRegs
        {
            get { return noRegs; }
            set { noRegs = value; }

        }

        public override string ToString()
        {
            return "ID: "+ raceID + ", engine capacity: " + engineCap + ", empty seats: " + noCont + ", number of registrations: " + noRegs;
        }
    }

}
