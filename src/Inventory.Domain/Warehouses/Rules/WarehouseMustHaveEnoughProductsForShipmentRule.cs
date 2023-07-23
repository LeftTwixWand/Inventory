using BuildingBlocks.Domain.BusinessRules;
using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses.Rules;

internal sealed record WarehouseMustHaveEnoughProductsForShipmentRule(int QuantityForShipment, IWarehouseAccountant WarehouseAccountant, ProductId ProductId) : IBusinessRule
{
    private readonly int actualProductsQuantity = WarehouseAccountant.GetActualProductQuantity();

    public string Message => "There are not enough products in warehouse to perform shipment.";

    public bool BrokenWhen => actualProductsQuantity < QuantityForShipment;
}