using BuildingBlocks.Application.Queries;
using Inventory.Application.Models;
using MediatR;

namespace Inventory.Application.DomainOperations.Product.GetProductById;

internal sealed record GetProductByIdQuery(int ProductId) : QueryBase<ProductModel?>;