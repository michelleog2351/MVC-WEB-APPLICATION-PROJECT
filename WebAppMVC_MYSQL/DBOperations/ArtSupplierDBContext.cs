using Microsoft.EntityFrameworkCore;
using MyWebAppMVC.Models;

namespace MyWebAppMVC.DBOperations
{
    public class ArtSupplierDBContext : DbContext
    {
        public ArtSupplierDBContext(DbContextOptions<ArtSupplierDBContext> options) : base(options)
        {

        }

        public DbSet<ArtSupplier> ArtSuppliers { get; set; }
        public DbSet<ArtSupply> ArtSupplies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
