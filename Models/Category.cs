using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string? Description { get; set; } // Optional brief summar

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp

        // Navigation Property (optional, for EF Core use)
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
