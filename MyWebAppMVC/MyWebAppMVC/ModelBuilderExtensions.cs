using Microsoft.EntityFrameworkCore;
using MyWebAppMVC.Models;
using System.Net;

namespace MyWebAppMVC
{
    internal static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Warehouse>()
                .HasData(
                new Warehouse { Id = 1, Name = "Warehouse1", ContactNo = "0872734567", Address = "123, Downing Street, Dublin", Location = "Ireland" },
                new Warehouse { Id = 2, Name = "Warehouse2", ContactNo = "0834562874", Address = "375, Beauvelgrade Street, Paris", Location = "France" },
                new Warehouse { Id = 3, Name = "Warehouse3", ContactNo = "0865748902", Address = "421, Unter den Linden, Berlin", Location = "Germany" }
                );

            modelBuilder.Entity<Supplier>()
                .HasData(
                new Supplier { Id = 1, Name = "Evans Art", ContactNo = "0872662523", Email = "evansart@gmail.com"},
                new Supplier { Id = 2, Name = "Fine Art", ContactNo = "0861273743", Email = "fine.art@gmail.com" },
                new Supplier { Id = 3, Name = "Still Art", ContactNo = "0834567351", Email = "still.art@hotmail.com" });

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { 
                    Id = 1, 
                    Name = "Winsor & Newton", 
                    Quantity = 1,
                    Price = 1,
                },
                new Product
                {
                    Id = 2,
                    Name = "Faber Castell",
                    Quantity = 10,
                    Price = 10,
                },
                new Product
                {
                    Id = 3,
                    Name = "Premier",
                    Quantity=1,
                    Price = 1,
                }
                );
        }
    }
}
