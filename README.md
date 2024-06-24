# ApplicationConfiguration
## ASP.NET 8.0 Service utilized to bind ApplicationConfiguration section of configuration environment into a custom class for dependency injection

<hr />

[![GitHub license](https://img.shields.io/github/license/cdcavell/ApplicationConfiguration)](https://github.com/cdcavell/ApplicationConfiguration/blob/main/LICENSE)
[![GitHub top language](https://img.shields.io/github/languages/top/cdcavell/ApplicationConfiguration)](https://github.com/cdcavell/ApplicationConfiguration/blob/main/README.md)
[![GitHub language count](https://img.shields.io/github/languages/count/cdcavell/ApplicationConfiguration)](https://github.com/cdcavell/ApplicationConfiguration/blob/main/README.md)

<hr />

ApplicationConfiguration is a .Net 8.0 Service utilized to bind ApplicationConfiguration section of configuration
environment into a custom class for dependency injection.

Target Framework is [ASP.NET Core 8.0](https://dotnet.microsoft.com/download/dotnet/8.0). 
Developed and built in a Windows environment utilizing 
[Visual Studio Community 2022](https://visualstudio.microsoft.com/vs/) source-code editor. 



**_This work is [licensed](https://github.com/cdcavell/ApplicationConfiguration/blob/main/LICENSE) under the
[MIT License](https://opensource.org/licenses/MIT). Assets are licensed under their respective
[licensing](https://github.com/cdcavell/ApplicationConfiguration/blob/main/ASSETS-LICENSES.md)._**

<hr />

To utilize, add following to `Program.cs` where `AppConfig` is custom class to bind
ApplicationConfiguration section to:
```
    private static AppConfig? _applicationConfiguration;

    ...

    var builder = WebApplication.CreateBuilder(args);

    _applicationConfiguration = new(builder.Configuration);
    builder.Services.AddApplicationConfigurationService(options =>
    {
        options.ApplicationConfiguration = _applicationConfiguration;
    });
```

Example of custom class (requires IConfiguration passed into constructor):
```
    public class AppConfig(IConfiguration configuration) : ApplicationConfiguration.Models.ApplicationConfiguration(configuration)
    {
    }
```

If configuration environment has sections under ApplicationConfiguration section,
then each section is it's own class within custom class. Example:
```
    public class AppConfig(IConfiguration configuration) : ApplicationConfiguration.Models.ApplicationConfiguration(configuration)
    {
        public ConnectionStrings ConnectionStrings { get; set; } = new();
    }
```

```
    public class ConnectionStrings
    {
        public string ApplicationDbConnection { get; set; } = string.Empty;
    }
```

Custom class can now be utilized in dependency injection:
```
    public abstract class ApplicationBaseController<T>(
        ILogger<T> logger,
        IApplicationConfigurationService applicationConfigurationService
    ) : WebBaseController<ApplicationBaseController<T>>(logger) where T : ApplicationBaseController<T>
    {
        protected readonly AppConfig _applicationConfiguration = applicationConfigurationService.ToObject<AppConfig>();
    }
```

<hr />

_Authenticate to GitHub Packages:_
<br />_Replace `USERNAME` with your GitHub User Name_
<br />_Replace `YOUR_GITHUB_PAT` with your personal access token_
<br />_Replace `NAMESPACE` with the name of the personal account or organization to which your packages are scoped_

```
> dotnet nuget add source --username USERNAME --password YOUR_GITHUB_PAT --store-password-in-clear-text --name github "https://nuget.pkg.github.com/NAMESPACE/index.json"
```

_Publish Package:_ 
<br />_Replace `PACKAGE` with your NuGet Package Name_
<br />_Replace `YOUR_GITHUB_PAT` with your personal access token_

```
> dotnet nuget push "bin/Release/PACKAGE.nupkg"  --api-key YOUR_GITHUB_PAT --source "github"
```

<hr />