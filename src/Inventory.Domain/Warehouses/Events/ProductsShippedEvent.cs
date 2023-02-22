using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses.Events;

public sealed record ProductsShippedEvent(ProductId ProductId, int Count) : WarehouseEventBase(ProductId, Count);