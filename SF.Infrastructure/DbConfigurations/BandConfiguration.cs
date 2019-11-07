using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class BandConfiguration : IEntityTypeConfiguration<BandEntity>
    {
        public void Configure(EntityTypeBuilder<BandEntity> builder)
        {

            builder.ToTable("Bands");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(1000)
                .IsRequired();
        }
    }
}
