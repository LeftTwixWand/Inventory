using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;
using Inventory.Persistence.Database.Snapshots;

namespace Inventory.Persistence.Database.Repositories;

internal sealed class WarehouseRepository : IWarehouseRepository
{
    public Task<Warehouse> GetByIdAsync(ProductId productId, Snapshot snapshot, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}