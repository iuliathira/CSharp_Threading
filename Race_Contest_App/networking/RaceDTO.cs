using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace networking
{
    [Serializable]
    public class RaceDTO
    {
        int raceID;
        int engine;
        int noCont;
        int noRegs;

        public RaceDTO(int engine)
        {
            this.engine = engine;
        }

        public RaceDTO(int id, int eng, int noC, int noR)
        {
            this.raceID = id;
            this.engine = eng;
            this.noCont = noC;
            this.noRegs = noR;
        }

        public  int RaceID
        {
            get
            {
                return this.raceID;
            }
        }

        public  int Engine
        {
            get
            {
                return this.engine;
            }
        }

        public  int NoCont
        {
            get
            {
                return this.noCont;
            }
        }

        public  int NoRegs
        {
            get
            {
                return this.noRegs;
            }
        }

    }

}
