using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Persistence.Configurations.Application
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            // Primary Key
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            // Name
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200); 

            // Description
            builder.Property(x => x.Description)
                .HasMaxLength(500) 
                .IsRequired(false);

            // Relationships

            // Proposals 
            builder.HasMany(p => p.Proposals)
                .WithOne()
                .HasForeignKey("ProjectId") 
                .OnDelete(DeleteBehavior.Cascade); 

            // Orders 
            builder.HasMany(p => p.Orders)
                .WithOne(o => o.Project)
                .HasForeignKey(o => o.ProjectId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Tablo Adı
            builder.ToTable("Projects");
        }
    }
}
