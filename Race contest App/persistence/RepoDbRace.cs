using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using race.model;
using log4net;

namespace race.repository
{
    public class RepoDbRace : IRepoRace
    {

        IDictionary<String, string> props;
        private static readonly ILog log = LogManager.GetLogger("RepoDbRace");
        public RepoDbRace(IDictionary<String, string> props)
        {
            log.Info("Create RepoDbRace");
            this.props = props;
        }



        public void delete(Race entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Race> findAll()
        {
            log.Info("Find all races");
            IDbConnection con = DbUtils.getConnection(props);
            List<Race> races = new List<Race>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select raceID, engineCap, noCont, noRegs " +
                   "from Races";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idR = dataR.GetInt32(0);
                        int engC = dataR.GetInt32(1);
                        int nrC = dataR.GetInt32(2);
                        int nrR = dataR.GetInt32(3);

                        Race race = new Race(idR, engC, nrC, nrR);
                        races.Add(race);

                    }
                }
            }
            Console.WriteLine("stop");
            if (con.State == ConnectionState.Open)
                con.Close();
            return races;
        }

        public Race findOne(int id)
        {
            throw new NotImplementedException();
        }

        public Race getByTeam(int engine)
        {
            log.InfoFormat("find races by engine: {0}",engine);
            IDbConnection con = DbUtils.getConnection(props);
            
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select raceID, engineCap, noCont, noRegs " +
                   "from Races where engineCap=@eng";
                IDbDataParameter paramID = comm.CreateParameter();
                paramID.ParameterName = "@eng";
                paramID.Value = engine;
                comm.Parameters.Add(paramID);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idR = dataR.GetInt32(0);
                        int engC = dataR.GetInt32(1);
                        int nrC = dataR.GetInt32(2);
                        int nrR = dataR.GetInt32(3);

                        Race race = new Race(idR, engC, nrC, nrR);
                        return race;

                    }                }
            }
            Console.WriteLine("stop");
            if (con.State == ConnectionState.Open)
                con.Close();


            return null;
        }

        public IEnumerable<Race> getRacesByEngine(int engineCap)
        {
            IDbConnection con = DbUtils.getConnection(props);
            List<Race> races = new List<Race>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select raceID, engineCap, noCont, noRegs " +
                   "from Races WHERE engineCap =@engCap";
                IDbDataParameter paramEngine = comm.CreateParameter();
                paramEngine.ParameterName = "@engCap";
                paramEngine.Value = engineCap;
                comm.Parameters.Add(paramEngine);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idR = dataR.GetInt32(0);
                        //int engC = dataR.GetInt32(1);
                        int nrC = dataR.GetInt32(2);
                        int nrR = dataR.GetInt32(3);

                        Race race = new Race(idR, engineCap, nrC, nrR);
                        races.Add(race);

                    }
                }
            }

            if (con.State == ConnectionState.Open)
                con.Close();


            return races;

        }

        public void save(Race entity)
        {
            throw new NotImplementedException();
        }

        public void update(Race r)
        {
            log.InfoFormat("Update race {0} {1} {2} ", r.id, r.EngineCap, r.NoCont);
            var con = DbUtils.getConnection(props);
            using (var comm = con.CreateCommand())
            {
                //log.InfoFormat("Saving entity with id {0}", entity.id);
                comm.CommandText = "UPDATE Races SET noCont=@cont,noRegs=@reg WHERE raceID = @id;";

                var paramCont = comm.CreateParameter();
                paramCont.ParameterName = "@cont";
                paramCont.Value = r.NoCont;
                comm.Parameters.Add(paramCont);

                var paramReg = comm.CreateParameter();
                paramReg.ParameterName = "@reg";
                paramReg.Value = r.NoRegs;
                comm.Parameters.Add(paramReg);


                var paramID = comm.CreateParameter();
                paramID.ParameterName = "@id";
                paramID.Value = r.id;
                comm.Parameters.Add(paramID);



                var result = comm.ExecuteNonQuery();
                con.Close();
                if (result == 0)
                    throw new Exception("No contestant added!");
            }
            if (con.State == ConnectionState.Open)
                con.Close();
        }
    }
}
