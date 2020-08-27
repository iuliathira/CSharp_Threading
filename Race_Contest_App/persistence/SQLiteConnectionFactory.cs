using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace race.connection
{
    public class SQLiteConnectionFactory : ConnectionFactory
    {
        public override IDbConnection createConnection(IDictionary<string, string> props)
        {
            String connectionString = "Data Source=DBs.db;Version=3";
            Console.WriteLine("S-a deschis o conexiune.");
            return new SQLiteConnection(connectionString);
        }
    }
}
