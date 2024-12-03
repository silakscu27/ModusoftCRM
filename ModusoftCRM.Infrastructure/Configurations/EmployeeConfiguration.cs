using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
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

            // MobilePhoneNumber configuration
            builder.Property(x => x.MobilePhoneNumber)
                .IsRequired()
                .HasMaxLength(11);

            // WorkPhoneNumber configuration
            builder.Property(x => x.WorkPhoneNumber)
                .IsRequired(false)
                .HasMaxLength(11);

            // Email configuration
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);

            // Department configuration
            builder.HasOne(x => x.Department)
                .WithMany()
                .HasForeignKey("DepartmentId")
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
            builder.ToTable("Employees");
        }
    }
}
