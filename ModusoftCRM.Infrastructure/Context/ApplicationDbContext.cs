﻿using GenericRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Application.Common.Interfaces;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Infrastructure.Context
{
    internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>, IApplicationDbContext
    {
        private readonly ITenantService _tenantService;

        public ApplicationDbContext(DbContextOptions options, ITenantService tenantService) : base(options)
        {
            _tenantService = tenantService;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<CompanyDetail> CompanyDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<FranchiseType> FranchiseTypes { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<FranchiseRepresentative> FranchiseRepresentatives { get; set; }
        public DbSet<FranchiseRepresentativeHistory> FranchiseRepresentativeHistories { get; set; } 
        public DbSet<ProductVariantUnitPrice> ProductVariantUnitPrices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<ProposalItem> ProposalItems { get; set; }

        public async Task<IApplicationDbContext> GetDbInstance(string tenantIdentifier, CancellationToken cancellationToken)
        {
            return await _tenantService.GetDbInstance(tenantIdentifier, cancellationToken);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);

            builder.Ignore<IdentityUserLogin<Guid>>(); 
            builder.Ignore<IdentityRoleClaim<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityUserRole<Guid>>();
            builder.Ignore<IdentityUserClaim<Guid>>();
        }
    }
}
