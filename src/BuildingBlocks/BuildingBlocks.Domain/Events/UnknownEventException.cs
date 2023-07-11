namespace BuildingBlocks.Domain.Events;

public class UnknownEventException : Exception
{
    public UnknownEventException(IDomainEventBase unknownEvent)
        : base($"No handler found for event {unknownEvent.GetType().FullName}")
    {
        UnknownEvent = unknownEvent;
    }

    public IDomainEventBase UnknownEvent { get; }

    /// <inheritdoc/>
    public override string ToString()
    {
        return $"No handler found for event {UnknownEvent.GetType().FullName}";
    }
}