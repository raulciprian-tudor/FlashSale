using System;

namespace FlashSale.Domain.Orders;

public class Order
{
    public Guid Id { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal TotalPrice => UnitPrice * Quantity;

    public Order(Guid productId, int quantity, decimal unitPrice)
    {
        if (productId == Guid.Empty)
        {
            throw new DomainException("Product id is required.");
        }

        if (quantity <= 0)
        {
            throw new DomainException("Quantity must be positive.");
        }

        if (unitPrice <= 0)
        {
            throw new DomainException("Unit price must be positive.");
        }

        Id = Guid.NewGuid();
        ProductId = productId;
        Quantity = quantity;
        UnitPrice = unitPrice;
    }
}
