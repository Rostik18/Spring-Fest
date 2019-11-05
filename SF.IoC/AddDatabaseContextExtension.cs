using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SF.Infrastructure;

namespace SF.IoC
{
    public static class AddDatabaseContextExtension
    {
        public static void AddDatabaseContext(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<SFDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
