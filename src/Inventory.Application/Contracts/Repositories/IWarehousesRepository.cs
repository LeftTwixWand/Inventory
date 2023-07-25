using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;

namespace Inventory.Application.Contracts.Repositories;

public interface IWarehousesRepository
{
    Task<Warehouse> GetByIdAsync(ProductId productId, CancellationToken cancellationToken);

    Task<IReadOnlyCollection<Warehouse>> GetManyByIdsAsync(List<ProductId> usedProducts, CancellationToken cancellationToken);
}