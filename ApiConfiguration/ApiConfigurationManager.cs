using ApiConfiguration.Env;
using System;

namespace ApiConfiguration
{
    public enum EEnvironment
    {
        None = 0,
        Dev,
        Local,
        Product
    }

    public class ApiConfigurationManager : IApiConfigurationManager
    {
        private SystemSettings _systemSettings;
        private readonly EEnvironment _env;
        public ApiConfigurationManager(string env)
        {
            EEnvironment eEnvironment;
            Enum.TryParse(env, true, out eEnvironment);
            if (eEnvironment == EEnvironment.None)
            {
                throw new ArgumentException("env is null");
            }
            _env = eEnvironment;

        }
        public SystemSettings SystemSettings
        {
            get
            {
                if (_systemSettings != null)
                    return _systemSettings;
                _systemSettings = new SystemSettings(_env);
                return _systemSettings;
            }
        }
    }
}
