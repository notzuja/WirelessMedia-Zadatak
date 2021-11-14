using System;
using Microsoft.EntityFrameworkCore;
using WMPrakticniZadatak.Common.Models;

namespace WMPrakticniZadatak.DAL.Contexts
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Product>().Property(dbe => dbe.Price).HasColumnType("Money");
            
            // Seeding data
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.NewGuid(), Name = "Hemijska olovka", Description = "Hemijska olovka, 0.5mm, plava", Category = "Uredski pribor", Manufacturer = "Pilot", Supplier = "Dobavljac 1", Price = 1099.99m },
                new Product { Id = Guid.NewGuid(), Name = "Makaze", Description = "Makaze za papir", Category = "Uredski pribor", Manufacturer = "Maped", Supplier = "Dobavljac 1", Price = 569.99m },
                new Product { Id = Guid.NewGuid(), Name = "Heftalica", Description = "Heftalica", Category = "Uredski pribor", Manufacturer = "Maped", Supplier = "Dobavljac 1", Price = 779.99m },
                new Product { Id = Guid.NewGuid(), Name = "A4 papir", Description = "Pakovanje A4 papira za print, 500 kom, 80g", Category = "Uredski pribor", Manufacturer = "Double A", Supplier = "Dobavljac 1", Price = 895.99m },
                new Product { Id = Guid.NewGuid(), Name = "Tehnicka olovka", Description = "Tehnicka olovka, 0.7mm", Category = "Uredski pribor", Manufacturer = "Rotring", Supplier = "Dobavljac 1", Price = 1299.99m }
            );
        }
    }
}
