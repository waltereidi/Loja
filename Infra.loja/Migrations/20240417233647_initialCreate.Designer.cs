﻿// <auto-generated />
using System;
using Api.loja.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infra.loja.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20240417233647_initialCreate")]
    partial class initialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.loja.Entity.Categories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Dominio.loja.Entity.CategoriesPromotion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("categoriesPromotion");
                });

            modelBuilder.Entity("Dominio.loja.Entity.Clients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("nvarchar(320)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PermissionsGroupId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PermissionsGroupId");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("Dominio.loja.Entity.ClientsProductsCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientsId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ClientsId");

                    b.ToTable("clientsProductsCart");
                });

            modelBuilder.Entity("Dominio.loja.Entity.Integrations.WFileManager.FileDirectory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("DirectoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("FileDirectory");
                });

            modelBuilder.Entity("Dominio.loja.Entity.Integrations.WFileManager.FileStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FileDirectoryId")
                        .HasColumnType("int");

                    b.Property<long>("Length")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("FileStorage");
                });

            modelBuilder.Entity("Dominio.loja.Entity.Permissions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("permissions");
                });

            modelBuilder.Entity("Dominio.loja.Entity.PermissionsGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("permissionsGroup");
                });

            modelBuilder.Entity("Dominio.loja.Entity.PermissionsRelation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("PermissionsGroupId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionsId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PermissionsGroupId");

                    b.HasIndex("PermissionsId");

                    b.ToTable("permissionsRelation");
                });

            modelBuilder.Entity("Dominio.loja.Entity.Prices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("Price");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("prices");
                });

            modelBuilder.Entity("Dominio.loja.Entity.Products", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<long?>("Ean")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Sku")
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Dominio.loja.Entity.ProductsCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoriesId");

                    b.ToTable("productsCategories");
                });

            modelBuilder.Entity("Dominio.loja.Entity.ProductsPrices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("PricesId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.ToTable("productsPrices");
                });

            modelBuilder.Entity("Dominio.loja.Entity.ProductsStorage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId")
                        .IsUnique();

                    b.ToTable("productsStorage");
                });

            modelBuilder.Entity("Dominio.loja.Entity.ProductsSubCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("SubCategoriesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId")
                        .IsUnique();

                    b.ToTable("ProductsSubCategories");
                });

            modelBuilder.Entity("Dominio.loja.Entity.ProductsSubSubCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("SubSubCategoriesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId")
                        .IsUnique();

                    b.ToTable("ProductsSubSubCategories");
                });

            modelBuilder.Entity("Dominio.loja.Entity.RequestOrders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientsId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("requestOrders");
                });

            modelBuilder.Entity("Dominio.loja.Entity.RequestOrdersProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RequestOrdersId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RequestOrdersId");

                    b.ToTable("RequestOrdersProducts");
                });

            modelBuilder.Entity("Dominio.loja.Entity.SubCategories", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ID_Categories")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SubCategories");
                });

            modelBuilder.Entity("Dominio.loja.Entity.SubSubCategories", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubCategoriesId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("subSubCategories");
                });

            modelBuilder.Entity("Dominio.loja.Entity.CategoriesPromotion", b =>
                {
                    b.HasOne("Dominio.loja.Entity.Categories", "Categories")
                        .WithOne()
                        .HasForeignKey("Dominio.loja.Entity.CategoriesPromotion", "Id")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Dominio.loja.Entity.Clients", b =>
                {
                    b.HasOne("Dominio.loja.Entity.PermissionsGroup", "PermissionsGroup")
                        .WithMany()
                        .HasForeignKey("PermissionsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionsGroup");
                });

            modelBuilder.Entity("Dominio.loja.Entity.ClientsProductsCart", b =>
                {
                    b.HasOne("Dominio.loja.Entity.Clients", null)
                        .WithMany("ClientsProductsCart")
                        .HasForeignKey("ClientsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.Integrations.WFileManager.FileDirectory", b =>
                {
                    b.HasOne("Dominio.loja.Entity.Integrations.WFileManager.FileStorage", null)
                        .WithOne("Directory")
                        .HasForeignKey("Dominio.loja.Entity.Integrations.WFileManager.FileDirectory", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.PermissionsRelation", b =>
                {
                    b.HasOne("Dominio.loja.Entity.PermissionsGroup", null)
                        .WithMany("PermissionsRelations")
                        .HasForeignKey("PermissionsGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.loja.Entity.Permissions", "Permissions")
                        .WithMany()
                        .HasForeignKey("PermissionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Dominio.loja.Entity.Products", b =>
                {
                    b.HasOne("Dominio.loja.Entity.ClientsProductsCart", null)
                        .WithOne("Products")
                        .HasForeignKey("Dominio.loja.Entity.Products", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.loja.Entity.RequestOrdersProducts", null)
                        .WithOne("Products")
                        .HasForeignKey("Dominio.loja.Entity.Products", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.loja.Entity.ProductsCategories", "ProductsCategories")
                        .WithOne("Products")
                        .HasForeignKey("Dominio.loja.Entity.Products", "Id")
                        .HasPrincipalKey("Dominio.loja.Entity.ProductsCategories", "ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductsCategories");
                });

            modelBuilder.Entity("Dominio.loja.Entity.ProductsCategories", b =>
                {
                    b.HasOne("Dominio.loja.Entity.CategoriesPromotion", null)
                        .WithMany("ProductsCategories")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.ProductsPrices", b =>
                {
                    b.HasOne("Dominio.loja.Entity.Products", null)
                        .WithMany("ProductsPrices")
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.ProductsStorage", b =>
                {
                    b.HasOne("Dominio.loja.Entity.Products", null)
                        .WithOne("ProductsStorage")
                        .HasForeignKey("Dominio.loja.Entity.ProductsStorage", "ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.ProductsSubCategories", b =>
                {
                    b.HasOne("Dominio.loja.Entity.Products", null)
                        .WithOne("ProductsSubCategories")
                        .HasForeignKey("Dominio.loja.Entity.ProductsSubCategories", "ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.ProductsSubSubCategories", b =>
                {
                    b.HasOne("Dominio.loja.Entity.Products", null)
                        .WithOne("ProductsSubSubCategories")
                        .HasForeignKey("Dominio.loja.Entity.ProductsSubSubCategories", "ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.RequestOrdersProducts", b =>
                {
                    b.HasOne("Dominio.loja.Entity.RequestOrders", null)
                        .WithMany("RequestOrdersProducts")
                        .HasForeignKey("RequestOrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.SubCategories", b =>
                {
                    b.HasOne("Dominio.loja.Entity.Categories", null)
                        .WithMany("SubCategories")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.SubSubCategories", b =>
                {
                    b.HasOne("Dominio.loja.Entity.SubCategories", null)
                        .WithMany("SubSubCategories")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.Categories", b =>
                {
                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Dominio.loja.Entity.CategoriesPromotion", b =>
                {
                    b.Navigation("ProductsCategories");
                });

            modelBuilder.Entity("Dominio.loja.Entity.Clients", b =>
                {
                    b.Navigation("ClientsProductsCart");
                });

            modelBuilder.Entity("Dominio.loja.Entity.ClientsProductsCart", b =>
                {
                    b.Navigation("Products")
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.Integrations.WFileManager.FileStorage", b =>
                {
                    b.Navigation("Directory")
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.PermissionsGroup", b =>
                {
                    b.Navigation("PermissionsRelations");
                });

            modelBuilder.Entity("Dominio.loja.Entity.Products", b =>
                {
                    b.Navigation("ProductsPrices");

                    b.Navigation("ProductsStorage")
                        .IsRequired();

                    b.Navigation("ProductsSubCategories")
                        .IsRequired();

                    b.Navigation("ProductsSubSubCategories")
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.ProductsCategories", b =>
                {
                    b.Navigation("Products")
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.RequestOrders", b =>
                {
                    b.Navigation("RequestOrdersProducts");
                });

            modelBuilder.Entity("Dominio.loja.Entity.RequestOrdersProducts", b =>
                {
                    b.Navigation("Products")
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.loja.Entity.SubCategories", b =>
                {
                    b.Navigation("SubSubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}