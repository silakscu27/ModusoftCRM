using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class FranchiseRepresentativeConfiguration : IEntityTypeConfiguration<FranchiseRepresentative>
    {
        public void Configure(EntityTypeBuilder<FranchiseRepresentative> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // FirstName configuration
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            // LastName configuration
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(50);

            // Description configuration
            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(250);

            // PhoneNumber configuration
            builder.Property(x => x.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(15);

            // MobilePhoneNumber configuration
            builder.Property(x => x.MobilePhoneNumber)
                .IsRequired(false)
                .HasMaxLength(15);

            // EmailAddress configuration
            builder.Property(x => x.EmailAddress)
                .IsRequired(false)
                .HasMaxLength(100);

            // LinkedIn configuration
            builder.Property(x => x.LinkedIn)
                .IsRequired(false)
                .HasMaxLength(100);

            // Franchise configuration
            builder.HasOne(x => x.Franchise)
                .WithMany()
                .HasForeignKey(x => x.FranchiseId)
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
            builder.ToTable("FranchiseRepresentatives");
        }
    }
}
