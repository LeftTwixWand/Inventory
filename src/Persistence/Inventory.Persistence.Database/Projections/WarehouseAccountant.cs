using Inventory.Application.Contracts.Repositories;
using Inventory.Application.Services.Domain;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;
using Inventory.Infrastructure.Services.DataAccess;
using Inventory.Persistence.Database.Projections;

namespace Inventory.Infrastructure.Services.Domain;

internal sealed class WarehouseAccountantService : IWarehouseAccountantService
{
    private readonly IWarehousesRepository _warehouseRepository;
    private readonly ISnapshotsRepository _snapshotsRepository;

    public WarehouseAccountantService(IWarehousesRepository warehouseRepository, ISnapshotsRepository snapshotsRepository)
    {
        _warehouseRepository = warehouseRepository;
        _snapshotsRepository = snapshotsRepository;
    }

    public async Task<IWarehouseAccountant> GetActualProductQuantityAccountant(ProductId productId, CancellationToken cancellationToken)
    {
        var snapshot = await _snapshotsRepository.GetLatestAsync(productId, cancellationToken);
        var warehouse = await _warehouseRepository.GetByIdAsync(productId, cancellationToken);

        return new ActualProductQuantityProjection(warehouse.DomainEvents, snapshot);
    }
}