using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebAppMVC.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name must be 100 characters or less.")]
        public string Name { get; set; }

        [Range(0, 200, ErrorMessage = "Quantity must be between 0 and 200.")]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        [Range(1, 200, ErrorMessage = "Price must be between 1 and 200.")]
        public decimal Price { get; set; }

        public string Image { get; set; } = string.Empty;

        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();

        public int WarehouseId {  get; set; } 

        public Warehouse Warehouse { get; set; }
    }
}