using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            // Id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // ProductId
            builder.Property(x => x.ProductId).IsRequired();
            builder.Property(x => x.ProductId).HasMaxLength(50);

            // Thickness
            builder.Property(x => x.Thickness).IsRequired();

            // Width
            builder.Property(x => x.Width).IsRequired();

            // Length
            builder.Property(x => x.Length).IsRequired();

            // BasePrice
            builder.Property(x => x.BasePrice).IsRequired().HasColumnType("decimal(18,2)");

            // StockCode
            builder.Property(x => x.StockCode).IsRequired(false);
            builder.Property(x => x.StockCode).HasMaxLength(100);

            // BrandId and BrandName
            builder.Property(x => x.BrandId).IsRequired(false);
            builder.Property(x => x.BrandName).IsRequired(false);
            builder.Property(x => x.BrandName).HasMaxLength(200);

            // ColourId and ColourName
            builder.Property(x => x.ColourId).IsRequired(false);
            builder.Property(x => x.ColourName).IsRequired(false);
            builder.Property(x => x.ColourName).HasMaxLength(200);

            // Relationships
            builder
                .HasMany(x => x.UnitPrices)
                .WithOne()
                .HasForeignKey("ProductVariantId")
                .OnDelete(DeleteBehavior.Cascade);

            // Table Name
            builder.ToTable("ProductVariants");
        }
    }
}
