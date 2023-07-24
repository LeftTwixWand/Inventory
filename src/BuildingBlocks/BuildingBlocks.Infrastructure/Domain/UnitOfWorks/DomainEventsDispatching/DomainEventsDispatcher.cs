using MediatR;

namespace BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DomainEventsDispatching;

/// <inheritdoc cref="IDomainEventsDispatcher"/>
public sealed class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly IMediator _mediator;
    private readonly IDomainEventsProvider _domainEventsProvider;

    public DomainEventsDispatcher(IMediator mediator, IDomainEventsProvider domainEventsProvider)
    {
        _mediator = mediator;
        _domainEventsProvider = domainEventsProvider;
    }

    public async Task DispatchEventsAsync(CancellationToken cancellationToken)
    {
        var domainEvents = _domainEventsProvider.GetAllDomainEvents();
        _domainEventsProvider.ClearAllDomainEvents();

        foreach (var domainEvent in domainEvents)
        {
            await _mediator.Publish(domainEvent, cancellationToken);
        }
    }
}