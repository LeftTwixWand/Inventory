using System.Reflection.Metadata;
using BuildingBlocks.Domain.AggregateRoots;
using BuildingBlocks.Domain.Entities;
using Inventory.Domain.Documents;
using Inventory.Domain.Orders;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses.Events;
using Inventory.Domain.Warehouses.Rules;

namespace Inventory.Domain.Warehouses;

public sealed class Warehouse : Entity<WarehouseEventBase>, IAggregateRoot
{
    private Warehouse(ProductId productId)
    {
        ProductId = productId;
    }

    public ProductId ProductId { get; init; }

    public static Warehouse Create(ProductId productId)
    {
        var warehouse = new Warehouse(productId);

        warehouse.AddDomainEvent(new WarehouseCreatedEvent(productId));

        return warehouse;
    }

    public void ShipProducts(int count, IWarehouseAccountant warehouseAccountant, DocumentId documentId)
    {
        CheckRule(new CountMustBeGreaterThanZeroRule(count));
        CheckRule(new WarehouseMustHaveEnoughProductsForShipmentRule(count, warehouseAccountant, ProductId));

        AddDomainEvent(new ProductsShippedEvent(ProductId, count, documentId));
    }

    public void ReceiveProducts(int count, DocumentId documentId)
    {
        CheckRule(new CountMustBeGreaterThanZeroRule(count));
        CheckRule(new AttachedDocumentIdMustNotBeEmptyRule(documentId));

        AddDomainEvent(new ProductsReceivedEvent(ProductId, count, documentId));
    }

    public void DeclareMissedProducts(int count, DocumentId documentId)
    {
        CheckRule(new CountMustBeGreaterThanZeroRule(count));
        CheckRule(new AttachedDocumentIdMustNotBeEmptyRule(documentId));

        AddDomainEvent(new ProductsMissedEvent(ProductId, count, documentId));
    }

    public void DeleteProduct(IProductsRepository productsRepository, IOrdersRepository ordersRepository)
    {
        bool productsIsUsed = ordersRepository.IsProductsUsed(ProductId)

        AddDomainEvent(new ProductDeactivatedEvent(ProductId, DocumentId.Empty));
    }
}