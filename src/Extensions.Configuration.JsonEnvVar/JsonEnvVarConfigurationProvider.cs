using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.Configuration
{
    internal class JsonEnvVarConfigurationProvider : ConfigurationProvider
    {
        private readonly string _envVar;

        private readonly bool _isOptional;

        public JsonEnvVarConfigurationProvider(string envVarName, bool isOptional)
        {
            _isOptional = isOptional;
            _envVar = envVarName;
        }

        public override void Load()
        {
            string value = Environment.GetEnvironmentVariable(_envVar);
            if (value == null)
            {
                if (_isOptional)
                {
                    value = "{}";
                }
                else
                {
                    throw new InvalidOperationException();
                }
            }

            byte[] bytes = Encoding.Default.GetBytes(value);
            using (var stream = new MemoryStream(bytes))
            {
                Data = JsonConfigurationFileParser.Parse(stream);
            }
        }
    }
}