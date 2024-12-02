using Microsoft.EntityFrameworkCore;
using MyWebAppMVC.Models;

namespace MyWebAppMVC.DBOperations
{
    public class WarehouseDBContext : DbContext
    {
        public WarehouseDBContext(DbContextOptions<WarehouseDBContext> options) : base(options)
        {

        }

        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
