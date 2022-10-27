﻿using BuildingBlocks.Application.CQRS.Queries;
using Inventory.Application.Models;

namespace Inventory.Application.DomainOperations.Product.GetProductById;

internal sealed record GetProductByIdQuery(int ProductId) : QueryBase<ProductModel?>;