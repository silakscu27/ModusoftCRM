using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class ProductVariantUnitPriceConfiguration : IEntityTypeConfiguration<ProductVariantUnitPrice>
    {
        public void Configure(EntityTypeBuilder<ProductVariantUnitPrice> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // ProductVariantId configuration
            builder.Property(x => x.ProductVariantId)
                .IsRequired();

            // FranchiseTypeId configuration
            builder.Property(x => x.FranchiseTypeId)
                .IsRequired();

            // FranchiseTypeName configuration
            builder.Property(x => x.FranchiseTypeName)
                .IsRequired()
                .HasMaxLength(100);

            // DiscountType configuration
            builder.Property(x => x.DiscountType)
                .IsRequired();

            // DiscountAmount configuration
            builder.Property(x => x.DiscountAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // UnitPrice configuration
            builder.Property(x => x.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Auditing fields
            builder.Property(x => x.CreatedByUserId)
                .IsRequired()
                .HasMaxLength(75);

            builder.Property(x => x.CreatedOn)
                .IsRequired();

            builder.Property(x => x.ModifiedByUserId)
                .IsRequired(false)
                .HasMaxLength(75);

            builder.Property(x => x.LastModifiedOn)
                .IsRequired(false);

            builder.Property(x => x.DeletedByUserId)
                .IsRequired(false)
                .HasMaxLength(75);

            builder.Property(x => x.DeletedOn)
                .IsRequired(false);

            builder.Property(x => x.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            // Table mapping
            builder.ToTable("ProductVariantUnitPrices");
        }
    }
}
