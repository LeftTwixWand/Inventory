using BuildingBlocks.Domain.Events;

namespace BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DomainEventsDispatching;

public interface IDomainEventsProvider
{
    IReadOnlyCollection<IDomainEventBase> GetAllDomainEvents();

    void ClearAllDomainEvents();
}