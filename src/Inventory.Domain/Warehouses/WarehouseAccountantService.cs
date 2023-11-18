using Inventory.Domain.Products;
using Inventory.Domain.Warehouses.Projections;
using Inventory.Domain.Warehouses.Snapshots;

namespace Inventory.Domain.Warehouses;

public sealed class WarehouseAccountantService(IWarehousesRepository warehouseRepository, ISnapshotsRepository snapshotsRepository)
{
    public async Task<ActualProductQuantityProjection> GetActualProductQuantity(ProductId productId, CancellationToken cancellationToken)
    {
        var snapshot = await snapshotsRepository.GetLatestAsync(productId, cancellationToken);
        var warehouse = await warehouseRepository.GetFromSnapshotAsync(productId, snapshot, cancellationToken);

        return new ActualProductQuantityProjection(warehouse.DomainEvents, snapshot);
    }
}