using Inventory.Domain.Documents;
using Inventory.Domain.Products;
using MediatR;

namespace Inventory.Domain.Warehouses.Events;

public sealed record ProductDeactivatedEvent(ProductId ProductId, int RemainingProductsQuantity, DocumentId DocumentId)
    : WarehouseEventBase(ProductId, RemainingProductsQuantity, DocumentId), INotification;