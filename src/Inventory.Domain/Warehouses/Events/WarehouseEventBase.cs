using BuildingBlocks.Domain.Events;
using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses.Events;

public abstract record WarehouseEventBase(int Count, string? Reason = default) : DomainEventBase;