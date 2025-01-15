using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class ProposalItemConfiguration : IEntityTypeConfiguration<ProposalItem>
    {
        public void Configure(EntityTypeBuilder<ProposalItem> builder)
        {
            // Id
            builder.HasKey(pi => pi.Id);
            builder.Property(pi => pi.Id).ValueGeneratedOnAdd();

            // ProposalId
            builder.Property(pi => pi.ProposalId).IsRequired();

            builder.HasOne(pi => pi.Proposal)
                .WithMany(p => p.ProposalItems)
                .HasForeignKey(pi => pi.ProposalId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProductVariantId
            builder.Property(pi => pi.ProductVariantId)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(pi => pi.ProductVariant)
                .WithMany()
                .HasForeignKey(pi => pi.ProductVariantId)
                .OnDelete(DeleteBehavior.Restrict);

            // Quantity
            builder.Property(pi => pi.Quantity)
                .IsRequired();

            // DiscountType
            builder.Property(pi => pi.DiscountType)
                .IsRequired();

            // DiscountAmount
            builder.Property(pi => pi.DiscountAmount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // UnitPrice
            builder.Property(pi => pi.UnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // FinalUnitPrice
            builder.Property(pi => pi.FinalUnitPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            // Table Name
            builder.ToTable("ProposalItems");
        }
    }
}
