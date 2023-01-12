using BuildingBlocks.Domain.Events;
using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses.Events;

public sealed record WarehouseCreatedEvent(ProductId ProductId) : DomainEventBase;