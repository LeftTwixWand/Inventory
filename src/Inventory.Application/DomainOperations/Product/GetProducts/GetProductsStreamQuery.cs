using Inventory.Application.Models;
using MediatR;

namespace Inventory.Application.DomainOperations.Product.GetProducts;

internal sealed record GetProductsStreamQuery : IStreamRequest<ProductModel>;