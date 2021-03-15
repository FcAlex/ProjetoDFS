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
        //public DbSet<Company> Companies { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        //public DbSet<Product> Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //createTableUser(builder);
            //createTableCompany(builder);
            CreateTablePurchase(builder);
            //createTableProduct(builder);
        }

        private void createTableProduct(ModelBuilder builder)
        {
            //
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

            SeedPurchase(entity);

        }

        private static void SeedPurchase(EntityTypeBuilder<Purchase> entity)
        {
            entity.HasData
                (
                    new Purchase 
                    { 
                        Id=101, 
                        Address="Rua do Bobos, nr. 0", 
                        Cep="61100-000", Date=DateTime.Now, 
                        PaymentMethod = PaymentMethod.InCash, 
                        Status = PurchaseStatus.Confirmed, 
                        UserId = 101,
                        Observation = "n.a",
                        ProductId = 102 
                    },
                    new Purchase
                    {
                        Id = 102,
                        Address = "Rua A, nr. 545",
                        Cep = "105120-000",
                        Date = DateTime.Now,
                        PaymentMethod = PaymentMethod.DebitCard,
                        Status = PurchaseStatus.Done,
                        UserId = 102,
                        Observation = "n.a",
                        ProductId = 101
                    }
                );
        }

        private void createTableCompany(ModelBuilder builder)
        {
            
        }

        private static void createTableUser(ModelBuilder builder)
        {
           //
        }

        private static void SeedUsers(EntityTypeBuilder<User> entity)
        {
            //
        }
    }
}
