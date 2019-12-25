using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class AdminConfiguration : IEntityTypeConfiguration<AdminEntity>
    {
        public void Configure(EntityTypeBuilder<AdminEntity> builder)
        {

            builder.ToTable("Admins");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Login)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(e => e.PasswordHash)
                .HasMaxLength(512)
                .IsRequired();

            builder.Property(e => e.PasswordSalt)
                .HasMaxLength(512)
                .IsRequired();

            builder.HasIndex(e => e.Login)
                .IsUnique();
        }
    }
}
