using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses.Events;

public sealed record WarehouseCreatedEvent(ProductId ProductId) : WarehouseEventBase(ProductId, 0);