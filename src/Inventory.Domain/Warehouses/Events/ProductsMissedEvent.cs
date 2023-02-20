namespace Inventory.Domain.Warehouses.Events;

public sealed record ProductsMissedEvent(int Count, string Reason) : WarehouseEventBase(Count, Reason);