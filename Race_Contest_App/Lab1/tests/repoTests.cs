using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab1.repository;
using Lab1.model;
using System.Collections;
using System.Diagnostics;
namespace Lab1.tests
{
    class repoTests
    {

        public repoTests()
        {

        }
        public void test()
        {
            IDictionary<String, string> props = new SortedList<String, String>();
            props.Add("ConnectionString", GetConnectionStringByName("testDB"));
            //repoContestants
            RepoDbContestant repoDbContestant = new RepoDbContestant(props);
            IEnumerable<Contestant> contestants = repoDbContestant.findAll();
            Console.WriteLine("Before add-------------------------");
            foreach (var c in contestants)
            {
                Console.Write(c.Name);
            }
            Console.WriteLine("After add-------------------------");
            repoDbContestant.save(new Contestant("Laura", "kawasaki", 125));
            foreach (var c in contestants)
            {
                Console.Write(c.Name);
            }
            IEnumerable<Contestant> conts = repoDbContestant.getRacesByTeam("yamaha");
            foreach (var c in conts)
            {
                Console.Write(c.Name);
            }
            repoDbContestant.delete(new Contestant(2,"Laura","kawasaki", 125));


        }

        static string GetConnectionStringByName(string name)
        {
            string retVal = null;
            //ConnectionStringSettings settings = ConfigurationManager.Conn
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                retVal = settings.ConnectionString;

            return retVal;
        }


    }
    
}
