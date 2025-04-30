using InventoryManagementApi.DTOs;
using InventoryManagementApi.Models;
using InventoryManagementApi.Services;
using InventoryManagementApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories() 
        { 

            var categories = await _categoryService.GetCategoriesAsync();
            if (!categories.Any())
            {
                return NotFound("No products found. Please create a product.");
            }
            return Ok(categories);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategory([FromBody] CategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            category.CreatedAt = DateTime.UtcNow;
            var createdCategory = await _categoryService.CreateCategoryAsync(category);
            return Ok(createdCategory);
        }

        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDTO>> UpdateCategory([FromBody] CategoryDTO category, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            category.CreatedAt = DateTime.UtcNow;
            var createdCategory = await _categoryService.UpdateCategoryAsync(category, id);
            return Ok(createdCategory);
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _categoryService.DeleteCategoryAsync(id));
        }
    }
}
