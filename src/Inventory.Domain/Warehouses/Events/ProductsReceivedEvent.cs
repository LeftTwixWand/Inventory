namespace Inventory.Domain.Warehouses.Events;

public sealed record ProductsReceivedEvent(int Count) : WarehouseEventBase(Count);