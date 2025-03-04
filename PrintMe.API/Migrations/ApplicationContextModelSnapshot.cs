﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PrintMe.Infrastructure.Database;

#nullable disable

namespace PrintMe.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PrintMe.Application.Entities.CatalogItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailableStock")
                        .HasColumnType("integer");

                    b.Property<int>("CatalogType")
                        .HasColumnType("integer");

                    b.Property<long>("Category")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsHorizontal")
                        .HasColumnType("boolean");

                    b.Property<int>("ItemOrder")
                        .HasColumnType("integer");

                    b.Property<int>("MaxStockThreshold")
                        .HasColumnType("integer");

                    b.Property<string>("Motto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("OnReorder")
                        .HasColumnType("boolean");

                    b.Property<string>("OriginalImage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("OriginalImageHeight")
                        .HasColumnType("integer");

                    b.Property<int>("OriginalImageWidth")
                        .HasColumnType("integer");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureFileName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("numeric(18,2)");

                    b.Property<int>("RestockThreshold")
                        .HasColumnType("integer");

                    b.Property<int?>("SalePercentage")
                        .HasColumnType("integer");

                    b.Property<string>("SearchParameters")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<long?>("Tags")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Catalog");
                });

            modelBuilder.Entity("PrintMe.Application.Entities.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PrintMe.Application.Entities.CatalogItem", b =>
                {
                    b.OwnsMany("PrintMe.Application.Entities.ProductImage", "ProductImages", b1 =>
                        {
                            b1.Property<int>("CatalogItemId")
                                .HasColumnType("integer");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<int>("Category")
                                .HasColumnType("integer");

                            b1.Property<string>("ImageUrl")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<int>("ProductId")
                                .HasColumnType("integer");

                            b1.Property<string>("ThumbnailUrl")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("CatalogItemId", "Id");

                            b1.ToTable("ProductImage");

                            b1.WithOwner()
                                .HasForeignKey("CatalogItemId");
                        });

                    b.Navigation("ProductImages");
                });
#pragma warning restore 612, 618
        }
    }
}
