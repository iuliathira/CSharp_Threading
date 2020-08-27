using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace services
{
    public class RaceException: Exception
    {
        public RaceException() : base()
        {

        }
        public RaceException(String msg) : base(msg) { }
        public RaceException(String msg, Exception ex): base(msg, ex) { }
    }
}
