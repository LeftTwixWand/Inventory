using BuildingBlocks.Domain.Events;

namespace Inventory.Domain.Shipments.Events;

public sealed record ShipmentSentDomainEvent(ShipmentId ShipmentId) : DomainEventBase;