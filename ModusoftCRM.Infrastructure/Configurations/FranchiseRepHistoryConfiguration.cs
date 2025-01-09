using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class FranchiseRepHistoryConfiguration : IEntityTypeConfiguration<FranchiseRepresentativeHistory>
    {
        public void Configure(EntityTypeBuilder<FranchiseRepresentativeHistory> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // FranchiseRepresentativeId configuration
            builder.Property(x => x.FranchiseRepresentativeId)
                .IsRequired();

            // FranchiseId configuration
            builder.Property(x => x.FranchiseId)
                .IsRequired();

            // From configuration
            builder.Property(x => x.From)
                .IsRequired();

            // To configuration
            builder.Property(x => x.To)
                .IsRequired();

            // Role configuration
            builder.Property(x => x.Role)
                .IsRequired()
                .HasMaxLength(100);

            // Description configuration
            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(500);

            // Relationships
            builder.HasOne(x => x.Franchise)
                .WithMany()
                .HasForeignKey(x => x.FranchiseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.FranchiseRepresentative)
                .WithMany()
                .HasForeignKey(x => x.FranchiseRepresentativeId)
                .OnDelete(DeleteBehavior.Restrict);

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
            builder.ToTable("FranchiseRepHistories");
        }
    }
}
