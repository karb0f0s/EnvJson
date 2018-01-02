# EnvJson
Store JSON configuration inside environment variables

I've combined Microsoft.Extensions.Configuration.EnvironmentVariables (reads environment variables) and Microsoft.Extensions.Configuration.Json (parses variable as JSON stream) from (https://github.com/aspnet/Configuration/tree/dev/src). 

As a result you can write             
```
var config = new ConfigurationBuilder()
                .AddJsonEnvironmentVariables("CI_BUILD_SETTINGS")
                .Build();
                
var testSettings = config.GetSection("Tests").Get<TestSettings>();
```
