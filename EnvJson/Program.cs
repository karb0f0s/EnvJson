using EnvJson.Config.EnvJson;
using Microsoft.Extensions.Configuration;
using System;

namespace EnvJson
{
    public class TestSettings
    {
        public bool Execute { get; set; }
        public int ChatId { get; set; }
        public string Name { get; set; }
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddJsonEnvironmentVariables("CI_BUILD_SETTINGS");

            var config = builder.Build();

            var testSettings = config.GetSection("Tests").Get<TestSettings>();

            Console.WriteLine($"{config["CI_BUILD_SETTINGS"]}");

            Console.WriteLine();
            Console.WriteLine($"{nameof(testSettings.Execute)}: {testSettings.Execute}");
            Console.WriteLine($"{nameof(testSettings.ChatId)}: {testSettings.ChatId}");
            Console.WriteLine($"{nameof(testSettings.Name)}: {testSettings.Name}");

            Console.ReadLine();
        }
    }
}