using System;
using System.Reflection;

namespace Repositories.ConnectionBase
{
    public sealed class DatabaseFactory
    {
        private DatabaseFactory() { }

        public static Database CreateDatabase(string providerName, string connectionString)
        {
            // Verify a DatabaseFactoryConfiguration line exists in the web.config.
            if (providerName.Length == 0)
            {
                throw new Exception("Database name not defined in DatabaseFactoryConfiguration section of web.config.");
            }
            try
            {
                // Find the class
                Type database = Type.GetType(providerName);
                // Get it's constructor
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });
                // Invoke it's constructor, which returns an instance.
                Database createdObject = (Database)constructor.Invoke(null);
                // Initialize the connection string property for the database.
                createdObject.connectionString = connectionString;
                // Pass back the instance as a Database
                return createdObject;
            }
            catch (Exception excep)
            {
                throw new Exception("Error instantiating database " + providerName + ". " + excep.Message);
            }
        }
    }
}
