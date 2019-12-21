using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class PartnerFestivalConfiguration : IEntityTypeConfiguration<PartnerFestivalEntity>
    {
        public void Configure(EntityTypeBuilder<PartnerFestivalEntity> builder)
        {
            builder.ToTable("PartnerFestivals");

            builder.HasKey(pf => new { pf.PartnerId, pf.FestivalId });

            builder
                .HasOne(pf => pf.Festival)
                .WithMany(f => f.PartnerFestivals)
                .HasForeignKey(pf => pf.FestivalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pf => pf.Partner)
                .WithMany(p => p.PartnerFestivals)
                .HasForeignKey(pf => pf.PartnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
