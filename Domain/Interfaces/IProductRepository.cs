using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    Task<Product?> GetProductByIdAsync(Guid id);
    Task AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task<IEnumerable<Product>> GetProductsAsync();
}