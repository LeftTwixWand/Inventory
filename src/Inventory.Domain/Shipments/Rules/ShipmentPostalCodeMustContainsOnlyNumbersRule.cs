using BuildingBlocks.Domain.BusinessRules;
using Inventory.Domain.OrderItems.Rules;

namespace Inventory.Domain.Shipments.Rules;

internal sealed record ShipmentPostalCodeMustContainsOnlyNumbersRule(string PostalCode) : IBusinessRule
{
    public string Message => "Shipment postal code must contains only numbers!";

    public bool BrokenWhen => PostalCode.All(char.IsNumber) is false;
}