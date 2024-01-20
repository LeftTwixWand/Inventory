using BuildingBlocks.Application.CQRS.Commands;
using Inventory.Application.Models;

namespace Inventory.Application.Features.Products.DeleteProducts;

internal sealed record DeleteProductsCommand(ProductModel[] Products) : CommandBase;