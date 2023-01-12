using BuildingBlocks.Domain.BusinessRules;
using Inventory.Domain.Warehouses.Projections;

namespace Inventory.Domain.Warehouses.Rules;

internal sealed record WarehouseMustHaveEnoughProductsForShipmentRule(CurrentStateProjection CurrentState, int QuantityForShipment) : IBusinessRule
{
    public string Message => "There are not enough products in warehouse to perform shipment.";

    public bool BrokenWhen => CurrentState.GetQuantity() < QuantityForShipment;
}