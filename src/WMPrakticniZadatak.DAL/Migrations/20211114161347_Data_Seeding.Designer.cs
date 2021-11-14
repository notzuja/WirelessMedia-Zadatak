﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WMPrakticniZadatak.DAL.Contexts;

#nullable disable

namespace WMPrakticniZadatak.DAL.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20211114161347_Data_Seeding")]
    partial class Data_Seeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WMPrakticniZadatak.DAL.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("857de063-30fb-4594-aedd-a9862c6eae6f"),
                            Category = "Uredski pribor",
                            Description = "Hemijska olovka, 0.5mm, plava",
                            Manufacturer = "Pilot",
                            Name = "Hemijska olovka",
                            Price = 1099.99m,
                            Supplier = "Dobavljac 1"
                        },
                        new
                        {
                            Id = new Guid("0df7071e-a1b9-4ae0-a4e5-0e8b768ef23e"),
                            Category = "Uredski pribor",
                            Description = "Makaze za papir",
                            Manufacturer = "Maped",
                            Name = "Makaze",
                            Price = 569.99m,
                            Supplier = "Dobavljac 1"
                        },
                        new
                        {
                            Id = new Guid("948382ff-d18c-4706-8218-0a0fb09ea916"),
                            Category = "Uredski pribor",
                            Description = "Heftalica",
                            Manufacturer = "Maped",
                            Name = "Heftalica",
                            Price = 779.99m,
                            Supplier = "Dobavljac 1"
                        },
                        new
                        {
                            Id = new Guid("0708fdb5-b6f3-401b-a9d7-54aa8872c8cd"),
                            Category = "Uredski pribor",
                            Description = "Pakovanje A4 papira za print, 500 kom, 80g",
                            Manufacturer = "Double A",
                            Name = "A4 papir",
                            Price = 895.99m,
                            Supplier = "Dobavljac 1"
                        },
                        new
                        {
                            Id = new Guid("8e358a35-3974-4ece-9b9b-264afd4a8078"),
                            Category = "Uredski pribor",
                            Description = "Tehnicka olovka, 0.7mm",
                            Manufacturer = "Rotring",
                            Name = "Tehnicka olovka",
                            Price = 1299.99m,
                            Supplier = "Dobavljac 1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
