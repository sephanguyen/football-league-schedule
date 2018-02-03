

using MySql.Data.MySqlClient;
using System.Data;

namespace Repositories.ConnectionBase
{
    public class MySqlDatabase : Database
    {
        public override IDbConnection CreateConnection()
        {
            return new MySqlConnection(connectionString);
        }

        
    }
}
