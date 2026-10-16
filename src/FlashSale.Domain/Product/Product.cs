using System;

namespace FlashSale.Domain.Products;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = "";
    public decimal Price { get; private set; }
    public int StockQuantity { get; private set; }

    public Product(string name, decimal price, int stockQuantity)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new DomainException("Invalid name provided.");
        }

        if (price <= 0)
        {
            throw new DomainException("Price must be greater than 0.");
        }

        if (stockQuantity < 0)
        {
            throw new DomainException("Initial Stock cannot be negative.");
        }

        Id = Guid.NewGuid();
        Name = name;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public void Reserve(int quantity)
    {
        if (quantity <= 0)
        {
            throw new DomainException("Reservation quantity must be positive.");
        }

        if (quantity > StockQuantity)
        {
            throw new DomainException("Not enough stock.");
        }

        StockQuantity -= quantity;
    }
}
