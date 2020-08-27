using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace race.model
{
    public class OfficePers:HasID<int>
    {
        private int opID;
        private String name;
        private String username;
        private String password;

        public OfficePers(int opID, String name, String username, String password)
        {
            this.opID = opID;
            this.name = name;
            this.username = username;
            this.password = password;
        }

        public OfficePers(String username, String pass)
        {
            this.username = username;
            this.password = pass;
        }


        public int id
        {
            get { return opID; }
            set { opID = value; }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }

        }

        public string Username
        {
            get { return username; }
            set { username = value; }

        }

        public string Password
        {
            get { return password; }
            set { password = value; }

        }

        public override string ToString()
        {
            return "[" + opID.ToString() + ", " + this.name +
                ", " + this.username + ", " + this.password + "]";
        }
    }
}
