using race.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using log4net;


namespace race.repository
{
    public class RepoDbContestant : IRepoContestant
    {
        //private static readonly ILog 
        IDictionary<String, string> props;
        private static readonly ILog log = LogManager.GetLogger("RepoDbContestant");
        public RepoDbContestant(IDictionary<String, string> props)
        {
            log.Info("Creating RepoDbContestant");
            this.props = props;
        }

        public void delete(Contestant entity)
        {
            log.InfoFormat("Deleting entity with id {0}", entity.id);
            var con = DbUtils.getConnection(props);
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "DELETE FROM Contestants WHERE contestantID = @id;";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@id";
                paramID.Value = entity.id;
                comm.Parameters.Add(paramID);
                var dataR = comm.ExecuteNonQuery();
                con.Close();
                if (dataR == 0)
                    Console.Write("No contestant deleted: " + entity);
            }
            if( con.State == ConnectionState.Open)
                con.Close();
        }

        public IEnumerable<Contestant> findAll()
        {
            IDbConnection con = DbUtils.getConnection(props);
            List<Contestant> contestants = new List<Contestant>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select contestantID, name, team, engineCap " +
                   "from Contestants";
              
                 using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idC = dataR.GetInt32(0);
                        string name = dataR.GetString(1);
                        string team = dataR.GetString(2);
                        int engC = dataR.GetInt32(3);

                        Contestant contestant = new Contestant(idC, name, team, engC);
                        contestants.Add(contestant);
    
                    }
                }
            }
            Console.WriteLine("stop");
            if (con.State == ConnectionState.Open)
                con.Close();


            return contestants;
        }

        public Contestant findOne(int id)
        {
            IDbConnection con = DbUtils.getConnection(props);

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select contestantID, name, team, engineCap " +
                    "from Contestants where contestantID=@id";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@id";
                paramID.Value = id;
                comm.Parameters.Add(paramID);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idC = dataR.GetInt32(0);
                        string name = dataR.GetString(1);
                        string team = dataR.GetString(2);
                        int engC = dataR.GetInt32(3);

                        Contestant contestant = new Contestant(idC, name, team, engC);
                        con.Close();
                        return contestant;
                    }
                }
            }
            if (con.State == ConnectionState.Open)
                con.Close();
            return null;
        }

        public IEnumerable<Contestant> getRacesByTeam(string team)
        {
            log.InfoFormat("Getting contestants with {0}",team);
            IDbConnection con = DbUtils.getConnection(props);
            List<Contestant> contestants = new List<Contestant>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select contestantID, name, team, engineCap " +
                   "from Contestants WHERE team=@t";
                IDbDataParameter paramTeam = comm.CreateParameter();
                paramTeam.ParameterName = "@t";
                paramTeam.Value = team;
                comm.Parameters.Add(paramTeam);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idC = dataR.GetInt32(0);
                        string name = dataR.GetString(1);
                        //string team = dataR.GetString(2);
                        int engC = dataR.GetInt32(3);

                        Contestant contestant = new Contestant(idC, name, team, engC);
                        contestants.Add(contestant);

                    }
                }
            }

            if (con.State == ConnectionState.Open)
                con.Close();


            return contestants;


        }

        public void save(Contestant entity)
        {
            var con = DbUtils.getConnection(props);
            using (var comm = con.CreateCommand())
            {
                log.InfoFormat("Saving entity with id {0}",entity.id);
                comm.CommandText = "INSERT INTO Contestants(name,team,engineCap) VALUES (@name, @team, @engCap);";
                

                var paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = entity.Name;
                comm.Parameters.Add(paramName);

                var paramTeam = comm.CreateParameter();
                paramTeam.ParameterName = "@team";
                paramTeam.Value = entity.Team;
                comm.Parameters.Add(paramTeam);

                var paramEng = comm.CreateParameter();
                paramEng.ParameterName = "@engCap";
                paramEng.Value = entity.EngineCap;
                comm.Parameters.Add(paramEng);

                var result = comm.ExecuteNonQuery();
                con.Close();
                if (result == 0)
                    throw new Exception("No contestant added!");

        
            }
            if (con.State == ConnectionState.Open)
                con.Close();

        }

        public void update(Contestant entity)
        {
            throw new NotImplementedException();
        }
    }
}
