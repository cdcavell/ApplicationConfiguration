using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Reflection;

namespace ApplicationConfiguration
{
    public class ApplicationConfigurationService(IOptions<ApplicationConfigurationServiceOptions> options) : IApplicationConfigurationService
    {
        private readonly Models.ApplicationConfiguration _applicationConfiguration = (Models.ApplicationConfiguration)options.Value.ApplicationConfiguration;
        private readonly string _rawJson = JsonConvert.SerializeObject(options.Value.ApplicationConfiguration);

        public string AssemblyName()
        {
            return _applicationConfiguration.AssemblyName;
        }

        public string AssemblyVersion()
        {
            return _applicationConfiguration.AssemblyVersion;
        }

        public string LastModifiedDate()
        {
            return _applicationConfiguration.LastModifiedDateTime.ToString("MM/dd/yyyy");
        }

        public string EnvironmentName()
        {
            return _applicationConfiguration.EnvironmentName;
        }

        public bool IsDevelopment()
        {
            return _applicationConfiguration.IsDevelopment;
        }

        public bool IsProduction()
        {
            return _applicationConfiguration.IsProduction;
        }

        public string ToJson()
        {
            return _rawJson;
        }

        public T ToObject<T>()
        {
            T? result = JsonConvert.DeserializeObject<T>(_rawJson);
            return result == null ? throw new NullReferenceException() : result;
        }
    }
}
