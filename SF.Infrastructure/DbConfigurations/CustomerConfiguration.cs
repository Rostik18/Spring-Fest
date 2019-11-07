using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SF.Domain.Entities;

namespace SF.Infrastructure.DbConfigurations
{
    class CustomerConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {

            builder.ToTable("Customers");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}
