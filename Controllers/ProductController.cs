using InventoryManagementApi.Data;
using InventoryManagementApi.DTOs;
using InventoryManagementApi.Models;
using InventoryManagementApi.Services;
using InventoryManagementApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InventoryManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var products = await _productService.GetPaginatedProductsAsync(pageNumber, pageSize);
            if (!products.Any())
            {
                return NotFound("No products found. Please create a product.");
            }
            return Ok(products);
        }

        //Create
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> CreateProduct([FromBody] ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            product.CreatedAt = DateTime.UtcNow;
            var createdProduct = await _productService.CreateProductAsync(product);
            return Ok(product);
        }

        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> UpdateProduct([FromBody] ProductDTO product, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            product.CreatedAt = DateTime.UtcNow;
            var updatedProduct = await _productService.UpdateProductAsync(product, id);
            return Ok(updatedProduct);
        }


        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _productService.DeleteProductAsync(id));
        }
    }
}
