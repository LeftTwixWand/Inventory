using BuildingBlocks.Application.Commands;

namespace Inventory.Application.Products.CreateNewProduct;

public record CreateNewProductCommand(string Name) : CommandBase;

public record CreateNewProductWithResultCommand(string Name) : CommandBase<string>;