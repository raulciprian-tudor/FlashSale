using System;

namespace FlashSale.Application.Features.Orders.PlaceOrder;

public sealed record PlaceOrderCommand(Guid ProductId, int Quantity);
