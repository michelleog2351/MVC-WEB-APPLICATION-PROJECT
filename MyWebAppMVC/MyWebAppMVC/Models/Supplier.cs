using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebAppMVC.Models
{
    [Table("supplier")]
    public class Supplier
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
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

    }
}
