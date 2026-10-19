using System;
using FlashSale.Domain.Orders;
namespace FlashSale.Domain.UnitTests;

public class OrderTests
{
    [Fact]
    public void Constructor_EmptyProductId_Throws()
    {
        Assert.Throws<DomainException>(() => new Order(Guid.Empty, 3, 19.90m));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_NonPositiveQuantity_Throws(int quantity)
    {
        Assert.Throws<DomainException>(() => new Order(Guid.NewGuid(), quantity, 19.90m));
    }
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_NonPositivePrice_Throws(decimal price)
    {
        Assert.Throws<DomainException>(() => new Order(Guid.NewGuid(), 20, price));
    }

    [Fact]
    public void Constructor_ValidInput_SetsProperties()
    {
        var productId = Guid.NewGuid();
        var order = new Order(productId, 29, 259.01m);

        Assert.Equal(productId, order.ProductId);
        Assert.Equal(29, order.Quantity);
        Assert.Equal(259.01m, order.UnitPrice);
    }

    [Fact]
    public void TotalPrice_IsUnitPriceTimesQuantity()
    {
        var order = new Order(Guid.NewGuid(), 20, 19.90m);

        Assert.Equal(398.00m, order.TotalPrice);
    }

}
