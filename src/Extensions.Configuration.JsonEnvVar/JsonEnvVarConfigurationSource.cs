// ReSharper disable CheckNamespace

namespace Microsoft.Extensions.Configuration
{
    internal class JsonEnvVarConfigurationSource : IConfigurationSource
    {
        public string EnvVarName { get; set; }

        public bool IsOptional { get; set; }

        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new JsonEnvVarConfigurationProvider(EnvVarName, IsOptional);
        }
    }
}