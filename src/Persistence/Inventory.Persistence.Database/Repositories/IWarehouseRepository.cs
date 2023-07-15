using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;
using Inventory.Persistence.Database.Snapshots;

namespace Inventory.Persistence.Database.Repositories;

public interface IWarehouseRepository
{
    Task<Warehouse> GetByIdAsync(ProductId productId, Snapshot snapshot);
}