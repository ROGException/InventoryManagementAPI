using InventoryManagementApi.Models;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementApi.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        //Foreign key
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
