using BuildingBlocks.Domain.Events;
using MediatR;

namespace BuildingBlocks.Application.DomainEvents;

public interface IDomainEventHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainEvent
{
}