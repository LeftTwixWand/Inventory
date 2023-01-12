using BuildingBlocks.Domain.Events;
using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses.Events;

public sealed record ProductShippedEvent(ProductId ProductId, int Count) : DomainEventBase;