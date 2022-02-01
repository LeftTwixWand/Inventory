using BuildingBlocks.Application.Commands;

namespace Inventory.Application.Products.CreateNewProduct;

public record CreateNewProductCommand(string Name) : CommandBase;
public record CreateNewProductCommandResult(string Name) : CommandBase<string>;