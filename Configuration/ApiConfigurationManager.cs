using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Configuration
{
    public enum ApiEnvironment
    {
        Dev,
        Test,
        Product
    }
    public class ApiConfigurationManager
    {
        private static ApiEnvironment Env
        {
            get
            {
                ApiEnvironment btcdEnvironment;
                var configuration = new Configuration()
                Enum.TryParse(ConfigurationManager.AppSettings["Env"], true, out btcdEnvironment);
                return btcdEnvironment;

            }
        }
    }
}
