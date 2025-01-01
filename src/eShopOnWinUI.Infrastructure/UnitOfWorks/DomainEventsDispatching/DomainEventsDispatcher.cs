using MediatR;

namespace eShopOnWinUI.Infrastructure.UnitOfWorks.DomainEventsDispatching;

/// <inheritdoc cref="IDomainEventsDispatcher"/>
public sealed class DomainEventsDispatcher(IMediator mediator, IDomainEventsProvider domainEventsProvider) : IDomainEventsDispatcher
{
    public async Task DispatchEventsAsync(CancellationToken cancellationToken)
    {
        var domainEvents = domainEventsProvider.GetAllDomainEvents();
        domainEventsProvider.ClearAllDomainEvents();

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }
    }
}