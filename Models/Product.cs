using System.ComponentModel.DataAnnotations;

namespace ShopEasy.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Range(0.01, 1000.00)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Url]
        public string ImageUrl { get; set; }

        [StringLength(100)]
        public string Category { get; set; }

    }
}
