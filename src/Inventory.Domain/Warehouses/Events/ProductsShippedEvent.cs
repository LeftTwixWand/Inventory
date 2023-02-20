namespace Inventory.Domain.Warehouses.Events;

public sealed record ProductsShippedEvent(int Count) : WarehouseEventBase(Count);