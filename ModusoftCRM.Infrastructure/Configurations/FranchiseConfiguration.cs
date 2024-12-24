using Finbuckle.MultiTenant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class FranchiseConfiguration : IEntityTypeConfiguration<Franchise>
    {
        public void Configure(EntityTypeBuilder<Franchise> builder)
        {
            // Id
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Name
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200);

            // Description
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(5000);

            // Address
            builder.Property(x => x.Address).HasMaxLength(500);

            // PostalCode
            builder.Property(x => x.PostalCode).HasMaxLength(20);

            // PhoneNumber
            builder.Property(x => x.PhoneNumber).HasMaxLength(15);

            // FaxNumber
            builder.Property(x => x.FaxNumber).HasMaxLength(15);

            // TaxId
            builder.Property(x => x.TaxId).HasMaxLength(50);

            // TaxAdministration
            builder.Property(x => x.TaxAdministration).HasMaxLength(100);

            // LegalTaxName
            builder.Property(x => x.LegalTaxName).HasMaxLength(200);

            // Latitude
            builder.Property(x => x.Latitude).HasPrecision(9, 6);

            // Longitude
            builder.Property(x => x.Longitude).HasPrecision(9, 6);

            // Picture
            builder.Property(x => x.Picture).HasMaxLength(500);

            // Website
            builder.Property(x => x.Website).HasMaxLength(200);

            // LinkedIn
            builder.Property(x => x.LinkedIn).HasMaxLength(200);

            // TrustLevel
            builder.Property(x => x.TrustLevel).IsRequired();

            // Relationships
            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.FranchiseType)
                .WithMany(x => x.Franchises)
                .HasForeignKey(x => x.FranchiseTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Common Fields
            builder.Property(x => x.CreatedByUserId).IsRequired();
            builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

            builder.Property(x => x.CreatedOn).IsRequired();

            builder.Property(x => x.ModifiedByUserId).IsRequired(false);
            builder.Property(x => x.ModifiedByUserId).HasMaxLength(75);

            builder.Property(x => x.LastModifiedOn).IsRequired(false);

            builder.Property(x => x.DeletedByUserId).IsRequired(false);
            builder.Property(x => x.DeletedByUserId).HasMaxLength(75);

            builder.Property(x => x.DeletedOn).IsRequired(false);

            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValueSql("0");

            // Multi-Tenant
            builder.IsMultiTenant();

            // Table Name
            builder.ToTable("Franchises");
        }
    }
}
