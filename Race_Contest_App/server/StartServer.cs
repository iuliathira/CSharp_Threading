using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using race.repository;
using System.Configuration;
using log4net.Config;
using services;
using serverTemplate;
using networking;
using System.Net.Sockets;
using System.Threading;

namespace server
{
    class StartServer
    {
        static void Main(string[] args)
        {
            XmlConfigurator.Configure(new System.IO.FileInfo(args[0]));
            IDictionary<String, string> props = new SortedList<String, String>();
            props.Add("ConnectionString", GetConnectionStringByName("labDB"));
            IRepoContestant repoContestant = new RepoDbContestant(props);
            IRepoRace repoRace = new RepoDbRace(props);
            IOfficePers officePersRepo = new RepoDbOfficePers(props);
            RepoDbRegistration repoDbRegistration = new RepoDbRegistration(props);
            IServer serverImpl = new ServerImpl(repoContestant, repoRace, officePersRepo, repoDbRegistration);
            SerialServer server = new SerialServer("127.0.0.1", 55555, serverImpl);
            server.Start();
            Console.WriteLine("Server started...");
            Console.ReadLine();
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

    public class SerialServer: ConcurrentServer
    {
        private IServer server;
        private RaceClientWorker worker;
        public SerialServer(string host, int port, IServer srv) : base(host, port)
        {
            this.server = srv;
            Console.WriteLine("Serial Server...");
        }

        protected override Thread createWorker(TcpClient client)
        {
            worker = new RaceClientWorker(server, client);
            return new Thread(new ThreadStart(worker.run));
        }
    }
}
