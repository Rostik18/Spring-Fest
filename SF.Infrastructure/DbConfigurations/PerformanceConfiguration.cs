using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class PerformanceConfiguration : IEntityTypeConfiguration<PerformanceEntity>
    {
        public void Configure(EntityTypeBuilder<PerformanceEntity> builder)
        {

            builder.ToTable("Performances");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.BeginingTime)
                .IsRequired();

            builder.Property(e => e.Duration)
                .IsRequired();

            builder
               .HasOne(p => p.Band)
               .WithMany(b => b.Performances)
               .HasForeignKey(p => p.BandId)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Stage)
                .WithMany(s => s.Performances)
                .HasForeignKey(p => p.StageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Festival)
                .WithMany(f => f.Performances)
                .HasForeignKey(p => p.FestivalId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
