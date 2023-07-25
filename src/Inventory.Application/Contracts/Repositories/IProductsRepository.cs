using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Domain.Products;

namespace Inventory.Application.Contracts.Repositories;

public interface IProductsRepository
{
    IAsyncEnumerable<Product> GetAllAsync(CancellationToken cancellationToken);

    Task<Product?> GetByIdAsync(ProductId id, CancellationToken cancellationToken);

    Task DeleteByIdAsync(ProductId id, CancellationToken cancellationToken);

    Task DeleteManyByIdAsync(ProductId productId, CancellationToken cancellationToken);
}