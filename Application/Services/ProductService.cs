using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class ProductService(IProductRepository productRepository) : IProductService
{
    public async Task<Product?> GetProductByIdAsync(Guid id)
    {
        return await productRepository.GetProductByIdAsync(id);
    }

    public async Task AddProductAsync(string name, decimal price)
    {
        var product = new Product(name, price);
        await productRepository.AddProductAsync(product);
    }

    public async Task UpdateProductAsync(Guid id, decimal newPrice)
    {
        var product = await productRepository.GetProductByIdAsync(id);
        product.UpdatePrice(newPrice);
        await productRepository.UpdateProductAsync(product);
    }
}