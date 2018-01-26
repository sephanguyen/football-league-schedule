using ApiConfiguration.Env;

namespace ApiConfiguration
{
    public interface IApiConfigurationManager
    {
        SystemSettings SystemSettings { get; }
    }
}
