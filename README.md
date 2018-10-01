# JsonEnvVar

Load JSON-serialized configurations from environment variables

This package has all the goodness in both `Microsoft.Extensions.Configuration.EnvironmentVariables`
(reads environment variables) and `Microsoft.Extensions.Configuration.Json` (parses variable as JSON stream)
from [aspnet/Configuration](https://github.com/aspnet/Configuration).

As a result you can write

```c#
var config = new ConfigurationBuilder()
                .AddJsonEnvironmentVariables("CI_BUILD_SETTINGS")
                .Build();

var testSettings = config.GetSection("Tests").Get<TestSettings>();
```

## How it Works

Check the ASP.NET Core 2.1 app in [sample project](./sample/sample).

Run it for the first time without providing any extra configuration:

```sh
$ dotnet run
info: Sample.Startup[0]
      ["foo:bar"] = baz
```

And once with `APP_SETTINGS` environment variable with a JSON-serialized value:

```sh
$ APP_SETTINGS='{"foo":{"bar":"quz"}}' dotnet run
info: Sample.Startup[0]
      ["foo:bar"] = quz
```

This time the value(`quz`) in our environment variable overrides the default `baz`.