using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;

namespace SF.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminEntity>().HasData(
                new AdminEntity
                {
                    Id = 1,
                    Login = "MasterOfPuppets",
                    Password = "Admin12345"
                });
        }
    }
}
