using BuildingBlocks.Domain.Events;
using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses.Events;

public sealed record ProductMissedEvent(ProductId ProductId, int Count, string Reason) : DomainEventBase;