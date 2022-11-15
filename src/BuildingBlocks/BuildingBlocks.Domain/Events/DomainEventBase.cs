namespace BuildingBlocks.Domain.Events;

/// <summary>
/// Domain event abstraction, that stores information, when the event was occurred on.
/// </summary>
public record DomainEventBase : IDomainEvent
{
    /// <inheritdoc/>
    public DateTime OccurredOn => DateTime.Now;

    // TODO: Add unique guid identifier for the future idempotence retrying mechanism.
}