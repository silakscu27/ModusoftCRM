using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Id
            builder.HasKey(oi => oi.Id);
            builder.Property(oi => oi.Id).ValueGeneratedOnAdd();

            // OrderId
            builder.Property(oi => oi.OrderId).IsRequired();

            // ProductVariantId
            builder.Property(oi => oi.ProductVariantId).HasMaxLength(100).IsRequired();

            // Quantity
            builder.Property(oi => oi.Quantity).IsRequired();

            // DiscountType
            builder.Property(oi => oi.DiscountType).IsRequired();

            // DiscountAmount
            builder.Property(oi => oi.DiscountAmount).IsRequired().HasColumnType("decimal(18,2)");

            // UnitPrice
            builder.Property(oi => oi.UnitPrice).IsRequired().HasColumnType("decimal(18,2)");

            // FinalUnitPrice
            builder.Property(oi => oi.FinalUnitPrice).IsRequired().HasColumnType("decimal(18,2)");

            // Relationships
            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oi => oi.ProductVariant)
                .WithMany()
                .HasForeignKey(oi => oi.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("OrderItems");
        }
    }
}
