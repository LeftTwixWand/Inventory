using BuildingBlocks.Domain.Notifications;
using MediatR;

namespace BuildingBlocks.Application.CQRS.DomainEvents;

public interface IDomainNotificationHandler<in TDomainNotification> : INotificationHandler<TDomainNotification>
    where TDomainNotification : IDomainNotification
{
}