using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class PurchaseConfiguration : IEntityTypeConfiguration<PurchaseEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseEntity> builder)
        {
            builder.ToTable("Purchases");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.IsAvailable)
                .HasDefaultValue(true)
                .IsRequired();

            builder.Property(e => e.BarCode)
                .IsRequired();

            builder
               .HasOne(p => p.Customer)
               .WithMany(c => c.Purchases)
               .HasForeignKey(p => p.CustomerId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Ticket)
                .WithMany(t => t.Purchases)
                .HasForeignKey(p => p.TicketId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
