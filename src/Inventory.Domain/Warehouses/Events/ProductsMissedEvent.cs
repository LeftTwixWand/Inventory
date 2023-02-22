using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses.Events;

public sealed record ProductsMissedEvent(ProductId ProductId, int Count, string Reason) : WarehouseEventBase(ProductId, Count, Reason);