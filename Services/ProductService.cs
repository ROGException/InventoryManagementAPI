using InventoryManagementApi.Data;
using InventoryManagementApi.DTOs;
using InventoryManagementApi.Models;
using InventoryManagementApi.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementApi.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _dataContext;
        public ProductService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<ProductDTO>> GetPaginatedProductsAsync(int pageNumber, int pageSize)
        {
            var products= await _dataContext.Products
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                CategoryId = p.CategoryId,
                Price = p.Price,
                QuantityInStock = p.QuantityInStock,
                CreatedAt = p.CreatedAt
            });
        }

        public async Task<ProductDTO> CreateProductAsync(ProductDTO productDTO)
        {
            var categoryIdExists = await _dataContext.Categories.AnyAsync(
                c => c.Id == productDTO.CategoryId);

            if (!categoryIdExists)
            {
                throw new ArgumentException($"Category with Id {productDTO.CategoryId} does not exist. Please enter a valid category Id.");
            }

            var product = new Product
            {
                Name = productDTO.Name,
                CategoryId = productDTO.CategoryId,
                Price = productDTO.Price,
                QuantityInStock = productDTO.QuantityInStock,
                CreatedAt = DateTime.UtcNow
            };
            _dataContext.Products.Add(product);
            await _dataContext.SaveChangesAsync();
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                QuantityInStock = product.QuantityInStock,
                CreatedAt = product.CreatedAt
            };
        }

        public async Task<ProductDTO> UpdateProductAsync(ProductDTO updatedProductDto, int id)
        {
            var productToUpdate = await _dataContext.Products.FindAsync(id);
            if (productToUpdate == null)
            {
                throw new ArgumentException($"No category with Id {id} exists.");
            }
            productToUpdate.Name = updatedProductDto.Name;
            productToUpdate.Price = updatedProductDto.Price;
            productToUpdate.QuantityInStock = updatedProductDto.QuantityInStock;
            productToUpdate.CreatedAt = updatedProductDto.CreatedAt;

            _dataContext.Products.Update(productToUpdate);
            await _dataContext.SaveChangesAsync();

            return new ProductDTO
            {
                Id = productToUpdate.Id,
                Name = productToUpdate.Name,
                Price = productToUpdate.Price,
                QuantityInStock = productToUpdate.QuantityInStock,
                CreatedAt = productToUpdate.CreatedAt
            };
        }
        public async Task<ProductDTO> DeleteProductAsync(int id)
        {
            var product = await _dataContext.Products.FindAsync(id);
            if(product == null)
            {
                throw new ArgumentException($"No product with Id {id} exists.");
            }
            _dataContext.Products.Remove(product);
             await _dataContext.SaveChangesAsync();

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Price = product.Price,
                QuantityInStock = product.QuantityInStock,
                CreatedAt = product.CreatedAt
            };
        }



    }
}
