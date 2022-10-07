﻿using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DomainEventsDispatching;
using MediatR;

namespace Inventory.Infrastructure.CQRS.Decorators.DomainEventsDispatching;

internal sealed class DomainEventsDispatcherNotificationHandlerDecorator<T> : INotificationHandler<T>
        where T : INotification
{
    private readonly INotificationHandler<T> _decorated;
    private readonly IDomainEventsDispatcher _domainEventsDispatcher;

    public DomainEventsDispatcherNotificationHandlerDecorator(IDomainEventsDispatcher domainEventsDispatcher, INotificationHandler<T> decorated)
    {
        _domainEventsDispatcher = domainEventsDispatcher;
        _decorated = decorated;
    }

    public async Task Handle(T notification, CancellationToken cancellationToken)
    {
        await _decorated.Handle(notification, cancellationToken);

        await _domainEventsDispatcher.DispatchEventsAsync(cancellationToken);
    }
}