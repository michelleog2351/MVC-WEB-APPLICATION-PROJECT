﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWebAppMVC.DBOperations;

#nullable disable

namespace MyWebAppMVC.Migrations
{
    [DbContext(typeof(ArtSupplierDBContext))]
    partial class ArtSupplierDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArtSupplierArtSupply", b =>
                {
                    b.Property<int>("ArtSuppliersId")
                        .HasColumnType("int");

                    b.Property<int>("ArtSuppliesId")
                        .HasColumnType("int");

                    b.HasKey("ArtSuppliersId", "ArtSuppliesId");

                    b.HasIndex("ArtSuppliesId");

                    b.ToTable("ArtSupplierArtSupply");
                });

            modelBuilder.Entity("MyWebAppMVC.Models.ArtSupplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("artsupplier");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Paint",
                            ContactNo = "0872662523",
                            Email = "evans.art@gmail.com",
                            Name = "Evans Art Supplies",
                            Price = 20m,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            Category = "Paintbrushes",
                            ContactNo = "0861273743",
                            Email = "fine.art@gmail.com",
                            Name = "Fine Art Supplies",
                            Price = 10m,
                            Quantity = 6
                        },
                        new
                        {
                            Id = 3,
                            Category = "Paper",
                            ContactNo = "0834567351",
                            Email = "still.art@hotmail.com",
                            Name = "Still Art Supplies",
                            Price = 50m,
                            Quantity = 50
                        });
                });

            modelBuilder.Entity("MyWebAppMVC.Models.ArtSupply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("artsupply");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisplayOrder = 1111,
                            Name = "Winsor & Newton"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisplayOrder = 2222,
                            Name = "Faber Castell"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisplayOrder = 3333,
                            Name = "Premier"
                        });
                });

            modelBuilder.Entity("ArtSupplierArtSupply", b =>
                {
                    b.HasOne("MyWebAppMVC.Models.ArtSupplier", null)
                        .WithMany()
                        .HasForeignKey("ArtSuppliersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWebAppMVC.Models.ArtSupply", null)
                        .WithMany()
                        .HasForeignKey("ArtSuppliesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
