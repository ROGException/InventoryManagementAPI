using InventoryManagementApi.DTOs;
using InventoryManagementApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApi.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetPaginatedProductsAsync(int pageNumber, int pageSize);
        public Task<ProductDTO> CreateProductAsync(ProductDTO product);
        public Task<ProductDTO> UpdateProductAsync(ProductDTO updatedProductDto, int id);
        public Task<ProductDTO> DeleteProductAsync(int id);
    }
}
