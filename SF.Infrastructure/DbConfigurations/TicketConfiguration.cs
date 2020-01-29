using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class TicketConfiguration : IEntityTypeConfiguration<TicketEntity>
    {
        public void Configure(EntityTypeBuilder<TicketEntity> builder)
        {

            builder.ToTable("Tickets");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Price)
                .IsRequired();

            builder.Property(e => e.BeginingTime)
                .IsRequired();

            builder.Property(e => e.Duration)
                .IsRequired();

            builder.Property(e => e.Type)
                .IsRequired();

            builder
               .HasOne(t => t.Festival)
               .WithMany(f => f.Tickets)
               .HasForeignKey(t => t.FestivalId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
