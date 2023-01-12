using BuildingBlocks.Domain.TypedIdValueBases;

namespace Inventory.Domain.Orders;

public sealed record OrderId(Guid Value) : TypedIdValueBase<Guid>(Value)
{
    public static OrderId New => new(Guid.NewGuid());
}