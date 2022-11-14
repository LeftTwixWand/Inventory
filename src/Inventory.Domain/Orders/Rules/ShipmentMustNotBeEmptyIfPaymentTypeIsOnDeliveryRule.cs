using BuildingBlocks.Domain.BusinessRules;
using Inventory.Domain.Shipments;

namespace Inventory.Domain.Orders.Rules;

internal sealed record ShipmentMustNotBeEmptyIfPaymentTypeIsOnDeliveryRule(PaymentType PaymentType, Shipment? Shipment) : IBusinessRule
{
    public string Message => "Shipment information must not be empty if payment will be executed on delivery.";

    public bool BrokenWhen
        => PaymentType == PaymentType.OnDelivery
        && Shipment is null;
}