using BuildingBlocks.Domain.Events;
using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses.Events;

public abstract record WarehouseEventBase(ProductId ProductId, int Count, string? Reason = default) : DomainEventBase;