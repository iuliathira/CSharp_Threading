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
    public class RepoDbRegistration : ICrudRepository<int, Registration>
    {
        IDictionary<String, string> props;
        public RepoDbRegistration(IDictionary<String, string> prop)
        {
            this.props = prop;
        }

        public void delete(Registration entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Registration> findAll()
        {
            IDbConnection con = DbUtils.getConnection(props);
            List<Registration> regs = new List<Registration>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select regID,opID,contID,raceID " +
                   "from Registrations";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int regID = dataR.GetInt32(0);
                        int opID = dataR.GetInt32(1);
                        int contID = dataR.GetInt32(2);
                        int raceID = dataR.GetInt32(3);

                        Registration registration = new Registration(regID, opID, contID, raceID);
                        regs.Add(registration);
                    }
                }
            }
            
            if (con.State == ConnectionState.Open)
                con.Close();
            return regs;
        }

        public Registration findOne(int id)
        {
            throw new NotImplementedException();
        }

        public void save(Registration entity)
        {
            IDbConnection con = DbUtils.getConnection(props);
            using (var comm= con.CreateCommand())
            {
                comm.CommandText = "INSERT INTO Registrations VALUES (@idR,@opID,@cID,@rID)";

                var paramID = comm.CreateParameter();
                paramID.ParameterName = "@idR";
                paramID.Value = entity.id;
                comm.Parameters.Add(paramID);

                var paramOp = comm.CreateParameter();
                paramOp.ParameterName = "@opID";
                paramOp.Value = entity.OpID;
                comm.Parameters.Add(paramOp);

                var paramC = comm.CreateParameter();
                paramC.ParameterName = "@cID";
                paramC.Value = entity.ContID;
                comm.Parameters.Add(paramC);

                var paramR = comm.CreateParameter();
                paramR.ParameterName = "@rID";
                paramR.Value = entity.RaceID;
                comm.Parameters.Add(paramR);

                var result = comm.ExecuteNonQuery();
                con.Close();
                if (result == 0)
                    throw new Exception("No registration saved!");
            }
            if (con.State == ConnectionState.Open)
                con.Close();


        }

        public void update(Registration entity)
        {
            throw new NotImplementedException();
        }
    }
}
