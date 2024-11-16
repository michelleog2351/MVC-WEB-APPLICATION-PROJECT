using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebAppMVC.Models
{
    [Table("artsupplier")]
    public class ArtSupplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal Price { get; set; }

        public string ContactNo { get; set; }

        public string Email { get; set; }

        public List<ArtSupply> ArtSupplies { get; set; } = new List<ArtSupply>();

    }
}
