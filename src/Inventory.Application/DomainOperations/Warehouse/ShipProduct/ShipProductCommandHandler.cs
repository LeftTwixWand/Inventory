using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.CQRS.Commands;
using Inventory.Domain.Warehouses;

namespace Inventory.Application.DomainOperations.Warehouse.ShipProduct;

internal sealed class ShipProductCommandHandler : ICommandHandler<ShipProductCommand>
{
    private readonly IWarehouseRepository _warehouseRepository;
    private readonly ICurrentStateService _currentStateService;

    public async Task Handle(ShipProductCommand request, CancellationToken cancellationToken)
    {
        Inventory.Domain.Warehouses.Warehouse warehouse = await _warehouseRepository.GetWarehouseByIdAsync(request.ProductId);
        var currentProductsQuantity = _currentStateService.GetCurrentProductsQuantity(request.ProductId);

        warehouse.ShipProducts(request.Count, _currentStateService);
        return Result??
    }
}