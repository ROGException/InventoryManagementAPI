using InventoryManagementApi.DTOs;
using InventoryManagementApi.Models;

namespace InventoryManagementApi.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        public Task<CategoryDTO> CreateCategoryAsync(CategoryDTO category);
        public Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO updatedCategoryDto, int id);
        public Task<CategoryDTO> DeleteCategoryAsync(int id);

    }
}
