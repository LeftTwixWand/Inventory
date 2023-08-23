using BuildingBlocks.Domain.Events;
using Inventory.Domain.Warehouses;
using Inventory.Domain.Warehouses.Events;
using Inventory.Persistence.Database.Snapshots;

namespace Inventory.Persistence.Database.Projections;

public sealed class ActualProductQuantityProjection : IWarehouseAccountant
{
    private readonly IReadOnlyCollection<WarehouseEventBase> _domainEvents;
    private int quantity;

    public ActualProductQuantityProjection(IReadOnlyCollection<WarehouseEventBase> domainEvents, Snapshot snapshot)
    {
        _domainEvents = domainEvents;
        quantity = snapshot.Quantity;
    }

    public int GetActualProductQuantity()
    {
        foreach (var domainEvent in _domainEvents)
        {
            quantity = domainEvent switch
            {
                WarehouseCreatedEvent @event => Apply(@event),
                ProductsShippedEvent @event => Apply(@event),
                ProductsReceivedEvent @event => Apply(@event),
                ProductsMissedEvent @event => Apply(@event),
                _ => throw new UnknownEventException(domainEvent)
            };
        }

        return quantity;
    }

    private static int Apply(WarehouseCreatedEvent @event)
    {
        return 0;
    }

    private int Apply(ProductsReceivedEvent @event)
    {
        return quantity + @event.Count;
    }

    private int Apply(ProductsShippedEvent @event)
    {
        return quantity - @event.Count;
    }

    private int Apply(ProductsMissedEvent @event)
    {
        return quantity - @event.Count;
    }
}