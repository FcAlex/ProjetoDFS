using Microsoft.EntityFrameworkCore;
using Server.Domains.Helpers;
using Server.Domains.Models;
using System;

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
            CreateTableProduct(builder);
            CreateTablePurchase(builder);
            base.OnModelCreating(builder);
        }

        private static void CreateTableProduct(ModelBuilder builder)
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

            entity.HasData(
                new Product 
                {
                    Id = 2,
                    Value = 5.0f,
                    CompanyId = 10,
                    Description = "Salgadinho",
                    Name = "Cheetos",
                    Observation = "n.a",
                    imageURL="https://a-static.mlcdn.com.br/618x463/cheetos-tubo-elma-chips-sabor-queijo-cheddar-45g/drogariaaraujosa/107646/d56f5c254b621b54d99a402b6cd80ff6.jpg"
                }
            );
        }

        private static void CreateTablePurchase(ModelBuilder builder)
        {
            var entity = builder.Entity<Purchase>();
            entity.ToTable("Purchases");

            entity.HasKey(purchase => purchase.Id);
            entity.Property(purchase => purchase.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(purchase => purchase.Value).IsRequired();

            //entity.Property(purchase => purchase.Date).IsRequired().HasConversion(date => date, date => TimeZoneInfo.ConvertTimeToUtc(date));
            entity.Property(purchase => purchase.Date).IsRequired();

            entity.Property(purchase => purchase.PaymentMethod).IsRequired().HasColumnName("Payment Method");

            entity.Property(purchase => purchase.Status).IsRequired().HasColumnName("Purchase Status");

            entity.Property(purchase => purchase.Observation).HasMaxLength(100);

            entity.Property(purchase => purchase.Cep).IsRequired();

            entity.Property(purchase => purchase.Address).IsRequired().HasMaxLength(50);

            entity.Property(purchase => purchase.ProductId).IsRequired();

            entity.Property(purchase => purchase.UserId).IsRequired();

            entity.HasData (
                new Purchase
                {
                    Id = 101,
                    Address = "Rua dos Bobos",
                    Name = "Compra Semanal",
                    Cep="63.640-000",
                    Date = DateTime.Now,
                    Observation = "n.a",
                    PaymentMethod = PaymentMethod.CreditCard,
                    ProductId = 2,
                    Status = PurchaseStatus.Canceled,
                    UserId = 101,
                    Value = 500.0f
                }
            );
        }

        private static void CreateTableCompany(ModelBuilder builder)
        {
            var entity = builder.Entity<Company>();

            entity.ToTable("Companies");

            entity.HasKey(company => company.Id);
            entity.Property(company => company.Id).IsRequired().ValueGeneratedOnAdd();

            entity.Property(company => company.FantasyName).IsRequired();

            entity.Property(user => user.CompanyName).IsRequired();

            entity.HasMany(company => company.Products).WithOne(product => product.Company).HasForeignKey(product => product.CompanyId);

            entity.HasData(new Company 
            { 
                Cnpj="47.960.950/0001-21", 
                CompanyName="MAGAZINE LUIZA S/A", 
                FantasyName="", 
                Id=10, 
                imageURL="https://www.eletrolar.com/wp-content/uploads/2019/10/0.png" 
            });
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

            entity.HasData(new User 
            { 
                Id=101, 
                Cpf="000.000.000-00", 
                Email="alex@example.com", 
                Name="Alex Sousa", 
                Password="12345678",
                imageURL="https://cdn.pixabay.com/photo/2014/07/09/10/04/man-388104_960_720.jpg"
            });
        }
    }
}
