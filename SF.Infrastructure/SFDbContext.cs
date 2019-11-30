using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;
using SF.Infrastructure.DbConfigurations;

namespace SF.Infrastructure
{
    public class SFDbContext : DbContext
    {
        public SFDbContext(DbContextOptions<SFDbContext> options) : base(options)
        {
        }

        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<BandEntity> Bands { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<FestivalEntity> Festivals { get; set; }
        public DbSet<GenreEntity> Genres { get; set; }
        public DbSet<PartnerEntity> Partners { get; set; }
        public DbSet<PerformanceEntity> Performances { get; set; }
        public DbSet<PurchaseEntity> Purchases { get; set; }
        public DbSet<StageEntity> Stages { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BandConfiguration());
            modelBuilder.ApplyConfiguration(new BandGenreConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new FestivalConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new PartnerConfiguration());
            modelBuilder.ApplyConfiguration(new PerformanceConfiguration());
            modelBuilder.ApplyConfiguration(new PurchaseConfiguration());
            modelBuilder.ApplyConfiguration(new StageConfiguration());
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());

            modelBuilder.Seed();
        }
    }
}
