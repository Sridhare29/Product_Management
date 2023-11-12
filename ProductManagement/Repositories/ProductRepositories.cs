using System;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Data;
using ProductManagement.Entities;

namespace ProductManagement.Repositories
{
	public class ProductRepositories : IProductRepositories
    {
        public readonly ProductDbContext _dbContext;
		public ProductRepositories(ProductDbContext dbContext)
		{
            this._dbContext = dbContext;
		}

        public async Task<Product> CreateAsync(Product product)
        {
            await _dbContext.products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteAsync(Guid id)
        {
            var existingProduct = await _dbContext.products.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProduct == null)
            {
                return null;
            }

            _dbContext.products.Remove(existingProduct);
            await _dbContext.SaveChangesAsync();
            return existingProduct;
        }

        public async Task<List<Product>> GetAllAync()
        {
            return await _dbContext.products.ToListAsync();

        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _dbContext.products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product?> UpdateAsync(Guid id, Product product)
        {
            var existingProduct = await _dbContext.products.FirstOrDefaultAsync(x => x.Id == id);

            if(existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.ProductImageUrl = product.ProductImageUrl;
            existingProduct.Price = product.Price;
            existingProduct.CategoryId = product.CategoryId;

            await _dbContext.SaveChangesAsync();
            return existingProduct;

        }
    }
}

