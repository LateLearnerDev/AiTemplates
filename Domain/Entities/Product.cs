namespace Domain.Entities;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public decimal Price { get; private set; }

    public static Product Create(string name, decimal price)
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price
        };
    }

    public void UpdatePrice(decimal newPrice)
    {
        Price = newPrice;
    }
}