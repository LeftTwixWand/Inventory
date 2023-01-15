using BuildingBlocks.Domain.Notifications;
using MediatR;

namespace BuildingBlocks.Application.CQRS.DomainEvents;

public interface IDomainNotificationHandler<in TDomainEvent> : INotificationHandler<TDomainEvent>
    where TDomainEvent : IDomainNotification
{
}