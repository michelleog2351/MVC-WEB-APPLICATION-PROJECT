using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC_MYSQL.Models
{
    [Table("warehouse")]
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string ContactNo { get; set; }

        public string Address { get; set; }

        public string Location { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

    }
}
