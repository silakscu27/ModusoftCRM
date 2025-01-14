﻿using Microsoft.EntityFrameworkCore;
using ModusoftCRM.Domain.Entities;

namespace ModusoftCRM.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
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
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}