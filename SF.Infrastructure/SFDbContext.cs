using Microsoft.EntityFrameworkCore;
using SF.Domain.Entities;

namespace SF.Infrastructure
{
    public class SFDbContext : DbContext
    {
        public SFDbContext(DbContextOptions<SFDbContext> options) : base(options)
        {
        }

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
        }
    }
}
