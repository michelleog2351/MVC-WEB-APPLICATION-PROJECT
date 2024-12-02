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
        public string Name { get; set; }

        public string ContactNo { get; set; }

        public string Email { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

    }
}
