using Inventory.Application.Models;
using MediatR;

namespace Inventory.Application.DomainOperations.Products.GetProducts;

internal sealed record GetProductsStreamQuery : IStreamRequest<ProductModel>;