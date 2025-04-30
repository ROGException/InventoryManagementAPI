using InventoryManagementApi.Data;
using InventoryManagementApi.DTOs;
using InventoryManagementApi.Models;
using InventoryManagementApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace InventoryManagementApi.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _dataContext;

      
        public CategoryService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _dataContext.Categories.AsNoTracking().ToListAsync();
            return categories.Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                CreatedAt = c.CreatedAt
            });
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            // Map CategoryDTO to Category
            var category = new Category
            {
                Name = categoryDTO.Name,
                Description = categoryDTO.Description,
                CreatedAt = DateTime.UtcNow // Set CreatedAt here
            };

            _dataContext.Categories.Add(category);
            await _dataContext.SaveChangesAsync();

            // Map saved Category back to CategoryDTO
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                CreatedAt = category.CreatedAt
            };
        }

        public async Task<CategoryDTO> DeleteCategoryAsync(int id)
        {
            var category = await _dataContext.Categories.FindAsync(id);
            if (category == null)
            {
                throw new ArgumentException($"No category with Id {id} exists.");
            }
            _dataContext.Categories.Remove(category);
            await _dataContext.SaveChangesAsync();

            return new CategoryDTO
            {
                Id =    category.Id,
                Name = category.Name,
                Description = category.Description,
                CreatedAt = category.CreatedAt
            };
        }

        public async Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO updatedCategoryDto, int id)
        {
            var categoryToUpdate = await _dataContext.Categories.FindAsync(id);
            if (categoryToUpdate == null)
            {
                throw new ArgumentException($"No category with Id {id} exists.");
            }
            categoryToUpdate.Name = updatedCategoryDto.Name;
            categoryToUpdate.Description = updatedCategoryDto.Description;
            categoryToUpdate.CreatedAt = updatedCategoryDto.CreatedAt;

            _dataContext.Categories.Update(categoryToUpdate);
            await _dataContext.SaveChangesAsync();

            return new CategoryDTO
            {
                Id = categoryToUpdate.Id,
                Name = categoryToUpdate.Name,
                Description = categoryToUpdate.Description,
                CreatedAt = categoryToUpdate.CreatedAt
            };
        }
    }
}
