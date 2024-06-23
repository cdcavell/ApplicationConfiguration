using Microsoft.Extensions.DependencyInjection;

namespace ApplicationConfiguration
{
    public static class ApplicationConfigurationServiceOptionsExtention
    {
        public static IServiceCollection AddApplicationConfigurationService(this IServiceCollection serviceCollection, Action<ApplicationConfigurationServiceOptions> options)
        {
            serviceCollection.AddScoped<IApplicationConfigurationService, ApplicationConfigurationService>();
            if (options == null)
                throw new ArgumentNullException(nameof(options), @"Missing required options for ApplicationConfigurationService.");

            serviceCollection.Configure(options);
            return serviceCollection;
        }
    }
}
