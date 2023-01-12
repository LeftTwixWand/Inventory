using BuildingBlocks.Domain.Events;
using Inventory.Domain.Warehouses.Events;

namespace Inventory.Domain.Warehouses.Projections;

internal sealed class CurrentStateProjection
{
    private readonly IReadOnlyCollection<IDomainEvent> _domainEvents;
    private int quantity = 0;

    public CurrentStateProjection(IReadOnlyCollection<IDomainEvent> domainEvents)
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
                ProductShippedEvent @event => Apply(@event),
                ProductReceivedEvent @event => Apply(@event),
                ProductMissedEvent @event => Apply(@event),
                _ => throw new UnknownEventException(domainEvent)
            };
        }

        return quantity;
    }

    private static int Apply(WarehouseCreatedEvent @event)
    {
        return 0;
    }

    private int Apply(ProductReceivedEvent @event)
    {
        return quantity + @event.Count;
    }

    private int Apply(ProductShippedEvent @event)
    {
        return quantity - @event.Count;
    }

    private int Apply(ProductMissedEvent @event)
    {
        return quantity - @event.Count;
    }
}