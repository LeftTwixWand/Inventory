using BuildingBlocks.Domain.TypedIdValueBases;

namespace Inventory.Domain.Shipments;

public sealed record ShipmentId(Guid Value) : TypedIdValueBase<Guid>(Value)
{
    public static ShipmentId Default => new(Guid.Empty);
}