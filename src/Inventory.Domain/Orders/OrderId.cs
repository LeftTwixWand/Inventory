using BuildingBlocks.Domain.TypedIdValueBases;

namespace Inventory.Domain.Orders;

public sealed record OrderId(int Value) : TypedIdValueBase<int>(Value)
{
    public static OrderId Default => new(0);
}