using BuildingBlocks.Domain.Entities;
using BuildingBlocks.Domain.Events;
using BuildingBlocks.Infrastructure.Domain.UnitOfWorks.DomainEventsDispatching;
using HarabaSourceGenerators.Common.Attributes;

namespace Inventory.Database.Domain.UnitOfWorks.DomainEventsDispatching;

[Inject]
public sealed partial class DomainEventsProvider : IDomainEventsProvider
{
    private readonly DatabaseContext _context;

    public void ClearAllDomainEvents()
    {
        var domainEntities = _context.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

        domainEntities
            .ForEach(entity => entity.Entity.ClearDomainEvents());
    }

    public IReadOnlyCollection<IDomainEvent> GetAllDomainEvents()
    {
        var domainEntities = _context.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

        return domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();
    }
}