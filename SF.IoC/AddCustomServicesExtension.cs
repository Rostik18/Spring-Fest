using Microsoft.Extensions.DependencyInjection;
using SF.Services;
using SF.Services.Interfaces;

namespace SF.IoC
{
    public static class AddCustomServicesExtension
    {
        public static void AddCustomServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAdminService, AdminService>();
            serviceCollection.AddTransient<IBandService, BandService>();
            serviceCollection.AddTransient<IGenreService, GenreService>();
        }
    }
}
