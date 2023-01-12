using BuildingBlocks.Domain.AggregateRoots;
using BuildingBlocks.Domain.Entities;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses.Events;
using Inventory.Domain.Warehouses.Projections;
using Inventory.Domain.Warehouses.Rules;

namespace Inventory.Domain.Warehouses;

public sealed class Warehouse : Entity, IAggregateRoot
{
    private readonly CurrentStateProjection _currentState;

    private Warehouse(ProductId productId)
    {
        ProductId = productId;
        _currentState = new(DomainEvents);
    }

    public ProductId ProductId { get; init; }

    public int Quantity => _currentState.GetQuantity();

    public static Warehouse Create(ProductId productId)
    {
        var warehouse = new Warehouse(productId);

        warehouse.AddDomainEvent(new WarehouseCreatedEvent(productId));

        return warehouse;
    }

    public void ShipProduct(int count)
    {
        CheckRule(new CountMustBeGreaterThanZeroRule(count));
        CheckRule(new WarehouseMustHaveEnoughProductsForShipmentRule(_currentState, count));

        AddDomainEvent(new ProductShippedEvent(ProductId, count));
    }
}