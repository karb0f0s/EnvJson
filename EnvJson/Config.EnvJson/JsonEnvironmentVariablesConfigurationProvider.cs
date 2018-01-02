using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;
using System.Text;

namespace EnvJson.Config.EnvJson
{
    public class JsonEnvironmentVariablesConfigurationProvider : ConfigurationProvider
    {
        private readonly string _prefix;

        public JsonEnvironmentVariablesConfigurationProvider() : this(string.Empty)
        { }

        public JsonEnvironmentVariablesConfigurationProvider(string prefix)
        {
            _prefix = prefix ?? string.Empty;
        }

        public override void Load()
        {
            byte[] bytes = Encoding.Default.GetBytes(Environment.GetEnvironmentVariable(_prefix));
            var stream = new MemoryStream(bytes);
            Data = JsonConfigurationFileParser.Parse(stream);
        }
    }
}