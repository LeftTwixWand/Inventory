using Inventory.Domain.Documents;
using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses.Events;

public sealed record ProductsShippedEvent(ProductId ProductId, int Count, DocumentId DocumentId) : WarehouseEventBase(ProductId, Count, DocumentId);