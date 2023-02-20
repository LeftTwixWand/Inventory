using BuildingBlocks.Domain.Events;
using Inventory.Domain.Warehouses.Events;

namespace Inventory.Domain.Warehouses.Projections;

internal sealed class CurrentStateProjection
{
    private readonly IReadOnlyCollection<WarehouseEventBase> _domainEvents;
    private int quantity = 0;

    public CurrentStateProjection(IReadOnlyCollection<WarehouseEventBase> domainEvents)
    {
        _domainEvents = domainEvents;
    }

    public int GetQuantity()
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