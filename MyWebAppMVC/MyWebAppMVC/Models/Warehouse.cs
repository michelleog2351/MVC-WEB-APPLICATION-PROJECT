using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebAppMVC.Models
{
    [Table("warehouse")]
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name must be 100 characters or less.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\+?[0-9 ]{10,15}$", ErrorMessage = "Invalid phone number format.")]
        public string ContactNo { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Address must be 250 characters or less.")]
        public string Address { get; set; }

        [StringLength(100, ErrorMessage = "Location must be 100 characters or less.")]
        public string Location { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

    }
}
