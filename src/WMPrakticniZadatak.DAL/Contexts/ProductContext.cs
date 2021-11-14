using Microsoft.EntityFrameworkCore;
using System.Data;
using WMPrakticniZadatak.DAL.Models;

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
            modelBuilder.Entity<Product>().HasKey(dbe => dbe.Id);
            modelBuilder.Entity<Product>().Property(dbe => dbe.Price).HasColumnType("Money");
        }
    }
}
