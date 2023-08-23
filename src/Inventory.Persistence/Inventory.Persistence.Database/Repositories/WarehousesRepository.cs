using Inventory.Application.Contracts.Repositories;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;

namespace Inventory.Persistence.Database.Repositories;

internal sealed class WarehousesRepository : IWarehousesRepository
{
    // Add optional includeEvents and the implementation should include snapshots logic
    public Task<Warehouse> GetByIdAsync(ProductId productId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Warehouse>> GetManyByIdsAsync(List<ProductId> usedProducts, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}