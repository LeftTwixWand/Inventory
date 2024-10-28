using BuildingBlocks.Domain.Events;

namespace eShopOnWinUI.Infrastructure.UnitOfWorks.DomainEventsDispatching;

public interface IDomainEventsProvider
{
    IReadOnlyCollection<IDomainEvent> GetAllDomainEvents();

    void ClearAllDomainEvents();
}