﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _02_Layout.Data;

namespace _02_Layout.Migrations
{
    [DbContext(typeof(_02_LayoutContext))]
    [Migration("20220214133156_FullData")]
    partial class FullData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Accounts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Ads", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Carts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountsID")
                        .HasColumnType("int");

                    b.Property<int>("ProductsID")
                        .HasColumnType("int");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountsID");

                    b.HasIndex("ProductsID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountsID")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductsID")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AccountsID");

                    b.HasIndex("ProductsID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.InvoiceDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartsId")
                        .HasColumnType("int");

                    b.Property<int>("InvoicesID")
                        .HasColumnType("int");

                    b.Property<int>("ProductsID")
                        .HasColumnType("int");

                    b.Property<int>("Quality")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartsId");

                    b.HasIndex("InvoicesID");

                    b.HasIndex("ProductsID");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Invoices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountsID")
                        .HasColumnType("int");

                    b.Property<string>("AdressOrder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BuyDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneOrder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountsID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.ProductTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Inventory")
                        .HasColumnType("int");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductTypesID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublicDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypesID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<int?>("AccountsId")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<int?>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Carts", b =>
                {
                    b.HasOne("_02_Layout.Areas.Admin.Models.Accounts", "Accounts")
                        .WithMany("Cartss")
                        .HasForeignKey("AccountsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_02_Layout.Areas.Admin.Models.Products", "Products")
                        .WithMany("Carts")
                        .HasForeignKey("ProductsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Comments", b =>
                {
                    b.HasOne("_02_Layout.Areas.Admin.Models.Accounts", "Accounts")
                        .WithMany("Commentss")
                        .HasForeignKey("AccountsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_02_Layout.Areas.Admin.Models.Products", "Products")
                        .WithMany("Commentss")
                        .HasForeignKey("ProductsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.InvoiceDetails", b =>
                {
                    b.HasOne("_02_Layout.Areas.Admin.Models.Carts", null)
                        .WithMany("InvoiceDetailss")
                        .HasForeignKey("CartsId");

                    b.HasOne("_02_Layout.Areas.Admin.Models.Invoices", "Invoices")
                        .WithMany()
                        .HasForeignKey("InvoicesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("_02_Layout.Areas.Admin.Models.Products", "Products")
                        .WithMany("InvoicesDetailss")
                        .HasForeignKey("ProductsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoices");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Invoices", b =>
                {
                    b.HasOne("_02_Layout.Areas.Admin.Models.Accounts", "Accounts")
                        .WithMany("Invoicess")
                        .HasForeignKey("AccountsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Products", b =>
                {
                    b.HasOne("_02_Layout.Areas.Admin.Models.ProductTypes", "ProductTypes")
                        .WithMany("Productss")
                        .HasForeignKey("ProductTypesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductTypes");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Rate", b =>
                {
                    b.HasOne("_02_Layout.Areas.Admin.Models.Accounts", "Accounts")
                        .WithMany("Rates")
                        .HasForeignKey("AccountsId");

                    b.HasOne("_02_Layout.Areas.Admin.Models.Products", "Products")
                        .WithMany("Rates")
                        .HasForeignKey("ProductsId");

                    b.Navigation("Accounts");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Accounts", b =>
                {
                    b.Navigation("Cartss");

                    b.Navigation("Commentss");

                    b.Navigation("Invoicess");

                    b.Navigation("Rates");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Carts", b =>
                {
                    b.Navigation("InvoiceDetailss");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.ProductTypes", b =>
                {
                    b.Navigation("Productss");
                });

            modelBuilder.Entity("_02_Layout.Areas.Admin.Models.Products", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Commentss");

                    b.Navigation("InvoicesDetailss");

                    b.Navigation("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}
