using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public required string Name { get; set; }

        //Foreign key
        public int CategoryId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity in stock must be greater than 0")]
        public int QuantityInStock { get; set; }

        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
