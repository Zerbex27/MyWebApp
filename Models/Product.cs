using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
