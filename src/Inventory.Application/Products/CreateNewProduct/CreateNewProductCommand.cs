using BuildingBlocks.Application.Commands;

namespace Inventory.Application.Products.CreateNewProduct;

public sealed record CreateNewProductCommand(string Name) : CommandBase;

public sealed record CreateNewProductWithResultCommand(string Name) : CommandBase<string>;