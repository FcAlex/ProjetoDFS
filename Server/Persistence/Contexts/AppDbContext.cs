using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Server.Domains.Helpers;
using Server.Domains.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            CreateTableUser(builder);
            CreateTableCompany(builder);
            CreateTablePurchase(builder);
            CreateTableProduct(builder);
            base.OnModelCreating(builder);
        }

        private void CreateTableProduct(ModelBuilder builder)
        {
            var entity = builder.Entity<Product>();
            entity.ToTable("Products");

            entity.HasKey(product => product.Id);
            entity.Property(product => product.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(product => product.Name).IsRequired();

            entity.Property(product => product.Description);

            entity.Property(product => product.Value).IsRequired();

            entity.Property(product => product.Observation);

            entity.HasIndex(product => product.CompanyId).IsUnique(true);

            entity.HasMany(product => product.Purchases).WithOne(purchase => purchase.Product).HasForeignKey(purchase => purchase.ProductId);
        }

        private static void CreateTablePurchase(ModelBuilder builder)
        {
            var entity = builder.Entity<Purchase>();
            entity.ToTable("Purchases");

            entity.HasKey(purchase => purchase.Id);
            entity.Property(purchase => purchase.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(purchase => purchase.Value).IsRequired();

            entity.Property(purchase => purchase.Date).IsRequired().HasConversion(date => date, date => TimeZoneInfo.ConvertTimeToUtc(date));

            entity.Property(purchase => purchase.PaymentMethod).IsRequired().HasColumnName("Payment Method");

            entity.Property(purchase => purchase.Status).IsRequired().HasColumnName("Purchase Status");

            entity.Property(purchase => purchase.Observation).HasMaxLength(100);

            entity.Property(purchase => purchase.Cep).IsRequired();

            entity.Property(purchase => purchase.Address).IsRequired().HasMaxLength(50);

            entity.HasIndex(purchase => purchase.ProductId).IsUnique(true);

            entity.HasIndex(purchase => purchase.UserId).IsUnique(true);

        }

        private void CreateTableCompany(ModelBuilder builder)
        {
            var entity = builder.Entity<Company>();

            entity.ToTable("Companies");

            entity.HasKey(company => company.Id);
            entity.Property(company => company.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(company => company.FantasyName).IsRequired();

            entity.Property(user => user.CompanyName).IsRequired();

            entity.HasMany(company => company.Products).WithOne(product => product.Company).HasForeignKey(product => product.CompanyId);
        }

        private static void CreateTableUser(ModelBuilder builder)
        {
            var entity = builder.Entity<User>();

            entity.ToTable("Users");

            entity.HasKey(user => user.Id);
            entity.Property(user => user.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(user => user.Name).IsRequired();

            entity.Property(user => user.Email).IsRequired();

            entity.Property(user => user.Password).IsRequired();

            entity.Property(user => user.Cpf).IsRequired();

            entity.HasMany(user => user.Purchases).WithOne(purchase => purchase.User).HasForeignKey(purchase => purchase.UserId);
        }
    }
}
