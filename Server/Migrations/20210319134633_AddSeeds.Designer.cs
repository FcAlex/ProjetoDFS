// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Persistence.Contexts;

namespace Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210319134633_AddSeeds")]
    partial class AddSeeds
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.4");

            modelBuilder.Entity("Server.Domains.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cnpj")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FantasyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            Cnpj = "00.000.000/0001-99",
                            CompanyName = "Alex Sousa ME",
                            FantasyName = "FcoAlex"
                        });
                });

            modelBuilder.Entity("Server.Domains.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompanyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Observation")
                        .HasColumnType("TEXT");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            CompanyId = 10,
                            Description = "Salgadinho",
                            Name = "Cheetos",
                            Observation = "n.a",
                            Value = 5f
                        });
                });

            modelBuilder.Entity("Server.Domains.Models.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observation")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<byte>("PaymentMethod")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Payment Method");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<byte>("Status")
                        .HasColumnType("INTEGER")
                        .HasColumnName("Purchase Status");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Value")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Purchases");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Address = "Rua dos Bobos",
                            Cep = "63.640-000",
                            Date = new DateTime(2021, 3, 19, 10, 46, 32, 553, DateTimeKind.Local).AddTicks(6773),
                            Observation = "n.a",
                            PaymentMethod = (byte)1,
                            ProductId = 2,
                            Status = (byte)5,
                            UserId = 101,
                            Value = 500f
                        });
                });

            modelBuilder.Entity("Server.Domains.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 101,
                            Cpf = "000.000.000-00",
                            Email = "alex@example.com",
                            Name = "Alex Sousa",
                            Password = "12345678"
                        });
                });

            modelBuilder.Entity("Server.Domains.Models.Product", b =>
                {
                    b.HasOne("Server.Domains.Models.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Server.Domains.Models.Purchase", b =>
                {
                    b.HasOne("Server.Domains.Models.Product", "Product")
                        .WithMany("Purchases")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Server.Domains.Models.User", "User")
                        .WithMany("Purchases")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Server.Domains.Models.Company", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Server.Domains.Models.Product", b =>
                {
                    b.Navigation("Purchases");
                });

            modelBuilder.Entity("Server.Domains.Models.User", b =>
                {
                    b.Navigation("Purchases");
                });
#pragma warning restore 612, 618
        }
    }
}
