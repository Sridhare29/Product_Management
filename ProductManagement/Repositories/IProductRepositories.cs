using System;
using ProductManagement.Entities;

namespace ProductManagement.Repositories
{
	public interface IProductRepositories
	{
        Task<List<Product>> GetAllAync();

        Task<Product?> GetByIdAsync(Guid id);

        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Guid id, Product product);

        Task<Product?> DeleteAsync(Guid id);
    }
}

