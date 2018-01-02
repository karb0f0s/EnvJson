using Microsoft.Extensions.Configuration;

namespace EnvJson.Config.EnvJson
{
    public static class JsonEnvironmentVariablesExtensions
    {
        public static IConfigurationBuilder AddJsonEnvironmentVariables(
                this IConfigurationBuilder configurationBuilder,
                string envVar)
        {
            configurationBuilder.Add(new JsonEnvironmentVariablesConfigurationSource { EnvVar = envVar });
            return configurationBuilder;
        }
    }
}