using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;
using Inventory.Domain.Warehouses.Snapshots;

namespace Inventory.Persistence.Database.Repositories;

internal sealed class WarehousesRepository : IWarehousesRepository
{
    // Add optional includeEvents and the implementation should include snapshots logic
    public Task<Warehouse> GetByIdAsync(ProductId productId, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Warehouse> GetFromSnapshotAsync(ProductId productId, Snapshot snapshot, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Warehouse>> GetManyByIdAsync(List<ProductId> usedProducts, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}