using Finbuckle.MultiTenant.EntityFrameworkCore.Stores.EFCoreStore;
using Finbuckle.MultiTenant.Stores;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Models;

namespace ModusoftCRM.Infrastructure.Persistence.Contexts
{
    public class MultiTenantStoreDbContext : EFCoreStoreDbContext<ModuSoftTenantInfo>
    {
        // AltuDev 
        //private const string CONNECTION_STRING = "Server=185.103.199.53;Database=ModusoftCRMTenants;Uid=altudev;Pwd=xzxg4JttrbzmnIJ2kjpE;";

        // ModusoftSQL 
        private const string CONNECTION_STRING = $@"Server=185.223.77.57\modusoftsql;Database=ModusoftCRMTenants;User Id=appuser;Password=j8YTJAFaE6GoVBX2JJdAebzUb;TrustServerCertificate=True";

        public MultiTenantStoreDbContext(DbContextOptions<MultiTenantStoreDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Altudev
            //optionsBuilder.UseMySql(CONNECTION_STRING, ServerVersion.AutoDetect(CONNECTION_STRING));

            // ModusoftSQL
            optionsBuilder.UseSqlServer(CONNECTION_STRING);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ServerId
            modelBuilder.Entity<ModuSoftTenantInfo>().Property(x => x.ServerId).IsRequired();
            modelBuilder.Entity<ModuSoftTenantInfo>().Property(x => x.ServerId).HasMaxLength(150);

            // UserId
            modelBuilder.Entity<ModuSoftTenantInfo>().Property(x => x.UserId).IsRequired();
            modelBuilder.Entity<ModuSoftTenantInfo>().Property(x => x.UserId).HasMaxLength(150);
            modelBuilder.Entity<ModuSoftTenantInfo>().HasIndex(x => x.UserId).IsUnique();


            base.OnModelCreating(modelBuilder);
        }
    }
}