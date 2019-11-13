using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SF.Mappers;

namespace SF.IoC
{
    public static class AddMapperExtension
    {
        public static void AddMapper(this IServiceCollection services)
        {

            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new ServicesMapperProfile());
                mc.AddProfile(new WebAPIMapperProfile());
                mc.AllowNullCollections = true;
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
