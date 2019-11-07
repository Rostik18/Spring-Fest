using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class PartnerConfiguration : IEntityTypeConfiguration<PartnerEntity>
    {
        public void Configure(EntityTypeBuilder<PartnerEntity> builder)
        {

            builder.ToTable("Partners");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder
               .HasOne(p => p.Festival)
               .WithMany(f => f.Partners)
               .HasForeignKey(p => p.FestivalId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
