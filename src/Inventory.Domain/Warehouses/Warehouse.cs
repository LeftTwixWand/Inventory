using BuildingBlocks.Domain.AggregateRoots;
using BuildingBlocks.Domain.Entities;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses.Events;
using Inventory.Domain.Warehouses.Projections;
using Inventory.Domain.Warehouses.Rules;

namespace Inventory.Domain.Warehouses;

public sealed class Warehouse : Entity<WarehouseEventBase>, IAggregateRoot
{
    private Warehouse(ProductId productId)
    {
        ProductId = productId;
    }

    public ProductId ProductId { get; init; }

    public static Warehouse Create(ProductId productId)
    {
        var warehouse = new Warehouse(productId);

        warehouse.AddDomainEvent(new WarehouseCreatedEvent(productId));

        return warehouse;
    }

    public void ShipProducts(int count)
    {
        CheckRule(new CountMustBeGreaterThanZeroRule(count));

        var currentState = new CurrentStateProjection(DomainEvents);
        CheckRule(new WarehouseMustHaveEnoughProductsForShipmentRule(currentState, count));

        AddDomainEvent(new ProductsShippedEvent(ProductId, count));
    }

    public void ReceiveProducts(int count)
    {
        CheckRule(new CountMustBeGreaterThanZeroRule(count));

        AddDomainEvent(new ProductsReceivedEvent(ProductId, count));
    }

    public void DeclareMissedProducts(int count, string reason)
    {
        CheckRule(new CountMustBeGreaterThanZeroRule(count));
        CheckRule(new ReasonMustNotBeEmptyRule(reason));

        AddDomainEvent(new ProductsMissedEvent(ProductId, count, reason));
    }
}