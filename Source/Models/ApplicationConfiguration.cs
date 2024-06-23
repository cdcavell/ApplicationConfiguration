using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ApplicationConfiguration.Models
{
    public abstract class ApplicationConfiguration
    {
        private static readonly string _assemblyName = Assembly.GetEntryAssembly()?.GetName()?.Name ?? String.Empty;
        private static readonly string _assemblyVersion = Assembly.GetEntryAssembly()?.GetName()?.Version?.ToString() ?? String.Empty;
        private static readonly string _assemblyLocation = Assembly.GetEntryAssembly()?.Location ?? String.Empty;
        private static readonly string _environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? String.Empty;
        private static readonly DateTime _lastModifiedDateTime = String.IsNullOrEmpty(_assemblyLocation) ? DateTime.MinValue : File.GetLastWriteTime(_assemblyLocation);

        protected ApplicationConfiguration(IConfiguration configuration)
        {
            configuration?.Bind("ApplicationConfiguration", this);
        }

        public string AssemblyName { get; } = _assemblyName;

        public string AssemblyVersion { get; } = _assemblyVersion;

        public string EnvironmentName { get; } = _environmentName;

        public bool IsDevelopment { get; } = _environmentName.Equals("Development", StringComparison.OrdinalIgnoreCase);

        public bool IsProduction { get; } = _environmentName.Equals("Production", StringComparison.OrdinalIgnoreCase);

        public DateTime LastModifiedDateTime { get; } = _lastModifiedDateTime;
    }
}
