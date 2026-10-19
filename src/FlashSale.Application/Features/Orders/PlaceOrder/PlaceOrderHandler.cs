using System;
using System.Threading;
using System.Threading.Tasks;
using FlashSale.Application.Abstractions.Persistence;
using FlashSale.Application.Common;
using FlashSale.Domain.Orders;

namespace FlashSale.Application.Features.Orders.PlaceOrder;

public sealed class PlaceOrderHandler
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public PlaceOrderHandler(IProductRepository productRepository, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> HandleAsync(PlaceOrderCommand command, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(command.ProductId, cancellationToken)
            ?? throw new NotFoundException($"Product with ID: {command.ProductId} was not found.");

        var order = new Order(product.Id, command.Quantity, product.Price);
        product.Reserve(command.Quantity);

        _orderRepository.Add(order);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return order.Id;
    }
}
