using Microsoft.EntityFrameworkCore;
using MyWebAppMVC.Models;

namespace MyWebAppMVC
{
    internal static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<ArtSupplier>()
                .HasData(
                new ArtSupplier { Id = 1, Name = "Evans Art Supplies", Category = "Paint", Quantity = 2, Price = 20, ContactNo = "0872662523", Email = "evans.art@gmail.com"},
                new ArtSupplier { Id = 2, Name = "Fine Art Supplies", Category = "Paintbrushes", Quantity = 6, Price = 10, ContactNo = "0861273743", Email = "fine.art@gmail.com" },
                new ArtSupplier { Id = 3, Name = "Still Art Supplies", Category = "Paper", Quantity = 50, Price = 50, ContactNo = "0834567351", Email = "still.art@hotmail.com" });

            modelBuilder.Entity<ArtSupply>()
                .HasData(
                new ArtSupply { 
                    Id = 1, 
                    Name = "Winsor & Newton", 
                    DisplayOrder = 1111,
                    CreatedDate = new DateTime(2024, 11, 14, 0, 0, 0)
                },
                new ArtSupply
                {
                    Id = 2,
                    Name = "Faber Castell",
                    DisplayOrder = 2222,
                    CreatedDate = new DateTime(2024, 11, 13, 0, 0, 0)
                },
                new ArtSupply
                {
                    Id = 3,
                    Name = "Premier",
                    DisplayOrder = 3333,
                    CreatedDate = new DateTime(2024, 11, 10, 0, 0, 0)
                }
                );
        }
    }
}
