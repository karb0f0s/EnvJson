// ReSharper disable once CheckNamespace

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddJsonEnvVar(
            this IConfigurationBuilder configurationBuilder,
            string envVar,
            bool optional = false
        )
        {
            configurationBuilder.Add(new JsonEnvVarConfigurationSource
            {
                EnvVarName = envVar,
                IsOptional = optional,
            });
            return configurationBuilder;
        }
    }
}