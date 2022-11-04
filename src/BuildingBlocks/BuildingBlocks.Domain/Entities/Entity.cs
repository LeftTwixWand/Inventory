using BuildingBlocks.Domain.BusinessRules;
using BuildingBlocks.Domain.Events;

namespace BuildingBlocks.Domain.Entities;

/// <summary>
/// Base class for entity in the domain layer.
/// </summary>
public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Occurred domain events.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Clear list of domain events for current entity object.
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    /// <summary>
    /// Checks business rule for Entity.
    /// </summary>
    /// <param name="rule">Business rule to check.</param>
    /// <exception cref="BusinessRuleValidationException">Exception can be thrown on invalid business rule.</exception>
    protected static void CheckRule(IBusinessRule rule)
    {
        if (rule.BrokenWhen())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    /// <summary>
    /// Add domain event to the collection of domain events for current entity.
    /// </summary>
    /// <param name="domainEvent">Occurred domain event.</param>
    /// <exception cref="ArgumentNullException">The domain event must not be empty.</exception>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}