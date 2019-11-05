using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SF.Services.Models;

namespace SF.IoC
{
    public static class AddAppSettingsConfigurationExtension
    {
        public static void AddAppSettingsConfiguration(this IServiceCollection serviceCollection, IConfiguration config)
        {
            serviceCollection.Configure<AppSettings>(options =>
            {
                config.GetSection(Constants.AppSettingsSection).Bind(options);
            });
            serviceCollection.AddSingleton<AppSettings>();
        }
    }
}
