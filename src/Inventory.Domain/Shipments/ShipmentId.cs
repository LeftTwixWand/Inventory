namespace Inventory.Domain.Shipments;

public sealed record ShipmentId(Guid Value)
{
    public static ShipmentId Default => new(Guid.Empty);
}