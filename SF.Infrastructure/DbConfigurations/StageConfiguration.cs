using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class StageConfiguration : IEntityTypeConfiguration<StageEntity>
    {
        public void Configure(EntityTypeBuilder<StageEntity> builder)
        {

            builder.ToTable("Stages");

            builder.HasKey(s => s.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
