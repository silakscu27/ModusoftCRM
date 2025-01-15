using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Id
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            // FranchiseId
            builder.Property(o => o.FranchiseId).IsRequired();

            // ProjectId
            builder.Property(o => o.ProjectId).IsRequired();

            // Name
            builder.Property(o => o.Name).HasMaxLength(200).IsRequired(false);

            // Description
            builder.Property(o => o.Description).HasMaxLength(5000).IsRequired(false);

            // No
            builder.Property(o => o.No).HasMaxLength(50).IsRequired(false);

            // Status
            builder.Property(o => o.Status).IsRequired();

            // Currency
            builder.Property(o => o.Currency).IsRequired();

            // Date
            builder.Property(o => o.Date).IsRequired();

            // ValidityDate
            builder.Property(o => o.ValidityDate).IsRequired();

            // ShortDescription
            builder.Property(o => o.ShortDescription).HasMaxLength(1000).IsRequired(false);

            // Details
            builder.Property(o => o.Details).HasMaxLength(10000).IsRequired(false);

            // UserId
            builder.Property(o => o.UserId).HasMaxLength(75).IsRequired(false);

            // TaxRate
            builder.Property(o => o.TaxRate).IsRequired();

            // TotalAmount
            builder.Property(o => o.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");

            // FinalAmount
            builder.Property(o => o.FinalAmount).IsRequired().HasColumnType("decimal(18,2)");

            // Relationships
            builder.HasOne(o => o.Franchise)
                .WithMany()
                .HasForeignKey(o => o.FranchiseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Project)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.ProjectId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("Orders");
        }
    }
}
