using System;
using System.Threading;
using System.Threading.Tasks;
using FlashSale.Domain.Products;

namespace FlashSale.Application.Abstractions.Persistence;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
