using BuildingBlocks.Domain.TypedIdValueBases;

namespace Inventory.Domain.Products;

public sealed record ProductId(Guid Value) : TypedIdValueBase<Guid>(Value)
{
    public static ProductId New => new(Guid.NewGuid());
}