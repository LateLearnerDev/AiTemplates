using Domain.Entities;

namespace Application.Interfaces;

public interface IProductService
{
    Task<Product?> GetProductByIdAsync(Guid id);
    Task AddProductAsync(string name, decimal price);
    Task UpdateProductAsync(Guid id, decimal newPrice);
}