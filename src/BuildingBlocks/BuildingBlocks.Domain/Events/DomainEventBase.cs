namespace BuildingBlocks.Domain.Events;

/// <summary>
/// Domain event abstraction, that stores information, when the event was occurred on.
/// </summary>
public record DomainEventBase : IDomainEvent
{
    /// <inheritdoc/>
    public DateTime OccurredOn
    {
        get => DateTime.Now;
    }
}