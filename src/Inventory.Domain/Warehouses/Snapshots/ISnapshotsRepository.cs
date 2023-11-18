using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses.Snapshots;

public interface ISnapshotsRepository
{
    Task<Snapshot> GetLatestAsync(ProductId productId, CancellationToken cancellationToken);
}