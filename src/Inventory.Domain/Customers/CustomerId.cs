using BuildingBlocks.Domain.TypedIdValueBases;
using Inventory.Domain.Products;

namespace Inventory.Domain.Customers;

public sealed record CustomerId(int Value) : TypedIdValueBase<int>(Value)
{
    public static CustomerId Default => new(0);
}