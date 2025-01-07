using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Name configuration
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Latitude configuration
            builder.Property(x => x.Latitude)
                .IsRequired(false)
                .HasColumnType("decimal(10, 8)");

            // Longitude configuration
            builder.Property(x => x.Longitude)
                .IsRequired(false)
                .HasColumnType("decimal(11, 8)");

            // Relationship configurations
            builder.HasMany(x => x.Cities)
                .WithOne()
                .HasForeignKey("CountryId")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Franchises)
                .WithOne()
                .HasForeignKey("CountryId")
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
            builder.ToTable("Countries");
        }
    }
}
