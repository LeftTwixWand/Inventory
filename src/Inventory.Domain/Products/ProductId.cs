using BuildingBlocks.Domain.TypedIdValueBases;

namespace Inventory.Domain.Products;

public sealed record ProductId(int Value) : TypedIdValueBase<int>(Value)
{
    public static ProductId Default => new(0);
}