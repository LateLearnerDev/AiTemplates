using Domain.Entities;

namespace Application.Products.Models;

public class ProductDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }

    public static ProductDto From(Product product)
    {
        return new()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }
}