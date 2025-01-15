using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class ProposalConfiguration : IEntityTypeConfiguration<Proposal>
    {
        public void Configure(EntityTypeBuilder<Proposal> builder)
        {
            // Id
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            // FranchiseId
            builder.Property(p => p.FranchiseId).IsRequired();

            // ProjectId
            builder.Property(p => p.ProjectId).HasMaxLength(36).IsRequired(false);
            
            // Name
            builder.Property(p => p.Name).HasMaxLength(200).IsRequired(false);

            // Description
            builder.Property(p => p.Description).HasMaxLength(5000).IsRequired(false);

            // No
            builder.Property(p => p.No).HasMaxLength(50).IsRequired(false);

            // Status
            builder.Property(p => p.Status).IsRequired();

            // Currency
            builder.Property(p => p.Currency).IsRequired();

            // Date
            builder.Property(p => p.Date).IsRequired();

            // ValidityDate
            builder.Property(p => p.ValidityDate).IsRequired();

            // ShortDescription
            builder.Property(p => p.ShortDescription).HasMaxLength(1000).IsRequired(false);

            // Details
            builder.Property(p => p.Details).HasMaxLength(10000).IsRequired(false);

            // UserId
            builder.Property(p => p.UserId).HasMaxLength(75).IsRequired(false);

            // TaxRate
            builder.Property(p => p.TaxRate).IsRequired();

            // TotalAmount
            builder.Property(p => p.TotalAmount).IsRequired().HasColumnType("decimal(18,2)");

            // FinalAmount
            builder.Property(p => p.FinalAmount).IsRequired().HasColumnType("decimal(18,2)");

            // Relationships
            builder.HasMany(p => p.ProposalItems)
                .WithOne(pi => pi.Proposal)
                .HasForeignKey(pi => pi.ProposalId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Franchise)
                .WithMany()
                .HasForeignKey(p => p.FranchiseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Project)
                .WithMany(pr => pr.Proposals)
                .HasForeignKey(p => p.ProjectId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Proposals");
        }
    }
}
