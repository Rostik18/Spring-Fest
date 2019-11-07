using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class GenreConfiguration : IEntityTypeConfiguration<GenreEntity>
    {
        public void Configure(EntityTypeBuilder<GenreEntity> builder)
        {

            builder.ToTable("Genres");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
