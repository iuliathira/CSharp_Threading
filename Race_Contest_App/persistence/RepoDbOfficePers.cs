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
    public class RepoDbOfficePers : IOfficePers
    {
        IDictionary<String, string> props;
        private static readonly ILog log = LogManager.GetLogger("RepoDbOfficePers"); 
        public RepoDbOfficePers(IDictionary<string, string> props)
        {
            log.Info("Creating RepoDbOfficePerson");
            this.props = props;
        }

        public void delete(OfficePers entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OfficePers> findAll()
        {
            throw new NotImplementedException();
        }

        public OfficePers findByUserPass(string username, string password)
        {
            IDbConnection con = DbUtils.getConnection(props);
            log.Info("Find user by username and password");
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * " +
                    "from OfficePers where username=@user and password = @password";
                IDbDataParameter paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@user";
                paramUsername.Value = username;
                comm.Parameters.Add(paramUsername);

                IDbDataParameter paramPass = comm.CreateParameter();
                paramPass.ParameterName = "@password";
                paramPass.Value = password;
                comm.Parameters.Add(paramPass);


                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idC = dataR.GetInt32(0);
                        string name = dataR.GetString(1);
                        string usern = dataR.GetString(2);
                        string pass = dataR.GetString(3);

                        OfficePers pers = new OfficePers(idC, name,usern ,pass);
                        con.Close();
                        return pers;
                    }
                }
            }
            if (con.State == ConnectionState.Open)
                con.Close();


            return null;
        }

        public OfficePers findOne(int id)
        {
            throw new NotImplementedException();
        }

        public void save(OfficePers entity)
        {
            throw new NotImplementedException();
        }

        public void update(OfficePers entity)
        {
            throw new NotImplementedException();
        }
    }
}
