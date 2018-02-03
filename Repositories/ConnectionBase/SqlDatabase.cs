using System.Data;
using System.Data.SqlClient;

namespace Repositories.ConnectionBase
{
    public class SqlDatabase : Database
    {
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
