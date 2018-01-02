using Microsoft.Extensions.Configuration;

namespace EnvJson.Config.EnvJson
{
    public class JsonEnvironmentVariablesConfigurationSource : IConfigurationSource
    {
        public string EnvVar { get; set; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new JsonEnvironmentVariablesConfigurationProvider(EnvVar);
        }
    }
}