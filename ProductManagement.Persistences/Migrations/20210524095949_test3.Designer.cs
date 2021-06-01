﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductManagement.Persistences;

namespace ProductManagement.Persistences.Migrations
{
    [DbContext(typeof(ProductDataContext))]
    [Migration("20210524095949_test3")]
    partial class test3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("ProductManagement.Domain.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProductManagement.Domain.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("DiscontinuedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int>("Rating")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("SupplierID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("SupplierID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductManagement.Domain.ProductCategory", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryID")
                        .HasColumnType("integer");

                    b.HasKey("ProductID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("ProductManagement.Domain.ProductDetail", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.HasKey("ProductID");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("ProductManagement.Domain.Supplier", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ProductManagement.Domain.Product", b =>
                {
                    b.HasOne("ProductManagement.Domain.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierID");
                });

            modelBuilder.Entity("ProductManagement.Domain.ProductCategory", b =>
                {
                    b.HasOne("ProductManagement.Domain.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductManagement.Domain.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductManagement.Domain.ProductDetail", b =>
                {
                    b.HasOne("ProductManagement.Domain.Product", "Product")
                        .WithOne("ProductDetail")
                        .HasForeignKey("ProductManagement.Domain.ProductDetail", "ProductID");
                });
#pragma warning restore 612, 618
        }
    }
}