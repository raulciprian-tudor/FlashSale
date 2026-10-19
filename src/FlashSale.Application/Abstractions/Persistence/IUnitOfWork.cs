using System;
using System.Threading;
using System.Threading.Tasks;

namespace FlashSale.Application.Abstractions.Persistence;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
