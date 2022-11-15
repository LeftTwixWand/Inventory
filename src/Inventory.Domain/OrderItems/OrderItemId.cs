using BuildingBlocks.Domain.TypedIdValueBases;

namespace Inventory.Domain.OrderItems;

public sealed record OrderItemId(int Value) : TypedIdValueBase<int>(Value)
{
    public static OrderItemId Default => new(0);
}