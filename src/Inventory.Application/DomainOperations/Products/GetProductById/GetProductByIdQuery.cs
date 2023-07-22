using System;
using BuildingBlocks.Application.CQRS.Queries;
using Inventory.Application.Models;

namespace Inventory.Application.DomainOperations.Products.GetProductById;

internal sealed record GetProductByIdQuery(Guid ProductId) : QueryBase<ProductModel?>;