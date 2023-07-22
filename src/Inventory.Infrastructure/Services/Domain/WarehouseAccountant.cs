using Inventory.Application.Services.Domain;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;
using Inventory.Domain.Warehouses.Projections;
using Inventory.Infrastructure.Services.DataAccess;
using Inventory.Persistence.Database.Repositories;

namespace Inventory.Infrastructure.Services.Domain;

internal class WarehouseAccountantService : IWarehouseAccountantService
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly ISnapshotsRepository _snapshotsRepository;

    public WarehouseAccountantService(IWarehouseRepository warehouseRepository, ISnapshotsRepository snapshotsRepository)
    {
        _warehouseRepository = warehouseRepository;
        _snapshotsRepository = snapshotsRepository;
    }

    public async Task<IWarehouseAccountant> GetActualProductQuantityAccountant(ProductId productId, CancellationToken cancellationToken)
    {
        var snapshot = await _snapshotsRepository.GetLatestAsync(productId, cancellationToken);
        var warehouse = await _warehouseRepository.GetByIdAsync(productId, snapshot, cancellationToken);

        return new ActualProductQuantityProjection(warehouse.DomainEvents, snapshot);
    }
}