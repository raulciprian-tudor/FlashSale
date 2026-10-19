using FlashSale.Domain.Orders;

namespace FlashSale.Application.Abstractions.Persistence;

public interface IOrderRepository
{
    void Add(Order order);
}
