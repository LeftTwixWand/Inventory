using BuildingBlocks.Domain.ValueObjects;

namespace Inventory.Domain.Shipments;

public record Shipment : ValueObject
{
    public string ShipAddress { get; private set; }

    public string ShipCity { get; private set; }

    public string ShipRegion { get; private set; }

    public string ShipCountryCode { get; private set; }

    public string ShipPostalCode { get; private set; }

    public DateTimeOffset? ShippedDate { get; private set; }

    public DateTimeOffset? DeliveredDate { get; private set; }

    public static Shipment Create()
    {
        return new Shipment();
    }
}