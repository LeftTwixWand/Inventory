using Inventory.Domain.Products;
using Inventory.Domain.Warehouses.Projections;
using Inventory.Domain.Warehouses.Snapshots;

namespace Inventory.Domain.Warehouses;

public sealed class WarehouseAccountantService(IWarehousesRepository warehousesRepository, ISnapshotsRepository snapshotsRepository) : IWarehouseAccountantService
{
    public async Task<ActualProductQuantityProjection> GetActualProductQuantityProjection(ProductId productId, CancellationToken cancellationToken)
    {
        var snapshot = await snapshotsRepository.GetLatestAsync(productId, cancellationToken);
        var warehouse = await warehousesRepository.GetFromSnapshotAsync(productId, snapshot, cancellationToken);

        return new ActualProductQuantityProjection(warehouse.DomainEvents, snapshot);
    }
}