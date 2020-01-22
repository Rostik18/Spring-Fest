using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class BandGenreConfiguration : IEntityTypeConfiguration<BandGenreEntity>
    {
        public void Configure(EntityTypeBuilder<BandGenreEntity> builder)
        {

            builder.ToTable("BandGenres");

            builder.HasKey(bg => new { bg.BandId, bg.GenreId });

            builder
                .HasOne(bg => bg.Band)
                .WithMany(b => b.BandGenres)
                .HasForeignKey(bg => bg.BandId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(bg => bg.Genre)
                .WithMany(g => g.BandGenres)
                .HasForeignKey(bg => bg.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
