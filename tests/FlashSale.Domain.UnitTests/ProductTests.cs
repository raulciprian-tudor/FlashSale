using System;
using FlashSale.Domain.Products;
namespace FlashSale.Domain.UnitTests;

public class ProductTests
{
    [Fact] // [Fact] = a single test case with no inputs
    public void Reserve_ValidQuantity_ReducesStock()
    {
        // Arrange: set up the situation
        var product = new Product("Sneakers", price: 99.90m, stockQuantity: 10);

        // Act: do the ONE thing being tested
        product.Reserve(3);

        // Assert: check the outcome
        Assert.Equal(7, product.StockQuantity);
    }

    [Fact]
    public void Reserve_QuantityExceedsStock_ThrowsAndKeepsStock()
    {
        var product = new Product("Sneakers", price: 99.90m, stockQuantity: 10);

        Assert.Throws<DomainException>(() => product.Reserve(11));

        Assert.Equal(10, product.StockQuantity);
    }

    [Fact]
    public void Constructor_NegativeStock_Throws()
    {
        Assert.Throws<DomainException>(() => new Product("Sneakers", 99.90m, -2));
    }

    [Fact]
    public void Constructor_ValidInput_SetsProperties()
    {
        var product = new Product("Sneakers", 99.90m, 10);

        Assert.Equal("Sneakers", product.Name);
        Assert.Equal(99.90m, product.Price);
        Assert.Equal(10, product.StockQuantity);
        Assert.NotEqual(Guid.Empty, product.Id);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_NonPositivePrice_Throws(int price)
    {
        Assert.Throws<DomainException>(() => new Product("Sneakers", price, 10));
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    public void Constructor_EmptyName_Throws(string name)
    {
        Assert.Throws<DomainException>(() => new Product(name, 20, 10));
    }

    [Theory] // [Theory] = the same test, run once per InlineData
    [InlineData(0)]
    [InlineData(-1)]
    public void Reserve_NonPositiveQuantity_Throws(int quantity)
    {
        var product = new Product("Sneakers", price: 99.90m, stockQuantity: 10);

        // Assert.Throws passes only if the code inside throws a DomainException
        Assert.Throws<DomainException>(() => product.Reserve(quantity));
    }
}
