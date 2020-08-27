using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace race.repository
{
    public static class DbUtils
    {
        private static IDbConnection instance = null;

        public static IDbConnection getConnection(IDictionary<string,string> props)
        {
            if ( instance==null || instance.State == System.Data.ConnectionState.Closed)
            {
                instance = getNewConnection(props);
                instance.Open();
            }
            return instance;
        }

        private static IDbConnection getNewConnection(IDictionary<string, string> props)
        {
            return connection.ConnectionFactory.getInstance().createConnection(props);
        }

        

    }

}
