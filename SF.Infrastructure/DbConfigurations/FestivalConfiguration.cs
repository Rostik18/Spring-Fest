using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class FestivalConfiguration : IEntityTypeConfiguration<FestivalEntity>
    {
        public void Configure(EntityTypeBuilder<FestivalEntity> builder)
        {

            builder.ToTable("Festivals");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Year)
                .HasMaxLength(4)
                .IsRequired();

            builder.Property(e => e.Location)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
