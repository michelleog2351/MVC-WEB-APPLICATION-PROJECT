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
                new Warehouse { Id = 1, Name = "Winsor & Newton", ContactNo = "0872734567", Address = "123, Downing Street, Dublin", Location = "Ireland" },
                new Warehouse { Id = 2, Name = "Faber-Castell", ContactNo = "0834562874", Address = "421, Unter den Linden, Berlin", Location = "France" },
                new Warehouse { Id = 3, Name = "Amazon", ContactNo = "0865748902", Address = "375, Beauvelgrade Street, Paris", Location = "Germany" }
                );

            modelBuilder.Entity<Supplier>()
                .HasData(
                new Supplier { Id = 1, Name = "Evans Art", ContactNo = "0872662523", Email = "evansart@gmail.com" },
                new Supplier { Id = 2, Name = "Still Art", ContactNo = "0861273743", Email = "still.art@hotmail.com" },
                new Supplier { Id = 3, Name = "Fine Art", ContactNo = "0834567351", Email = "fine.art@gmail.com" });

            modelBuilder.Entity<Product>()
                .HasData(
                new Product { 
                    Id = 1, 
                    Name = "Winsor & Newton Spray Paint", 
                    Quantity = 1,
                    Price = 30,
                    Image = @"Images\Product\spray_paint.jpg",
                    WarehouseId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Faber-Castell Sketch Pad",
                    Quantity = 3,
                    Price = 35,
                    Image = @"Images\Product\sketch_pad.jpg",
                    WarehouseId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "Premier A5 Paper",
                    Quantity = 2,
                    Price = 50,
                    Image = @"Images\Product\a5_paper.jpg",
                    WarehouseId = 3
                }
                );
        }
    }
}
