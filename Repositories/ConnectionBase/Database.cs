using System.Data;


namespace Repositories.ConnectionBase
{
    public abstract class Database
    {
        public string connectionString;
        #region Abstract Functions
        public abstract IDbConnection CreateConnection();
        #endregion
    }
}
