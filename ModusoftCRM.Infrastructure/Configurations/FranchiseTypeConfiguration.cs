using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class FranchiseTypeConfiguration : IEntityTypeConfiguration<FranchiseType>
    {
        public void Configure(EntityTypeBuilder<FranchiseType> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Name configuration
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Description configuration
            builder.Property(x => x.Description)
                .IsRequired(false)
                .HasMaxLength(250);

            // IsDefault configuration
            builder.Property(x => x.IsDefault)
                .IsRequired()
                .HasDefaultValue(false);

            // Franchises relationship configuration
            builder.HasMany(x => x.Franchises)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

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
            builder.ToTable("FranchiseTypes");
        }
    }
}
