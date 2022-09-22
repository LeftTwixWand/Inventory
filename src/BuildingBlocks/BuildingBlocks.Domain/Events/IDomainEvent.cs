using MediatR;

namespace BuildingBlocks.Domain.Events;

/// <summary>
/// Domain event abstraction, that stores information, when the event was occurred on.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Date and time, when the event was raised.
    /// </summary>
    DateTime OccurredOn { get; }
}