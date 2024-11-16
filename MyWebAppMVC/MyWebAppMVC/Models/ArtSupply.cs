using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyWebAppMVC.Models
{
    [Table("artsupply")]
    public class ArtSupply
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public List<ArtSupplier> ArtSuppliers { get; set; } = new List<ArtSupplier>();
    }
}