using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Configurations
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<CustomerType>
    {
        public void Configure(EntityTypeBuilder<CustomerType> builder)
        {
            // Tablo adı
            builder.ToTable("CustomerTypes");

            // Primary Key
            builder.HasKey(ct => ct.Id);

            // Kolonlar ve özellikleri
            builder.Property(ct => ct.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(ct => ct.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(ct => ct.Description)
                .HasMaxLength(500);

            // Varsayılan değerler
            builder.Property(ct => ct.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(ct => ct.IsDeleted)
                .HasDefaultValue(false);

            // Index (Performans için)
            builder.HasIndex(ct => ct.Name)
                .IsUnique();
        }
    }
}
