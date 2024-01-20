using Inventory.Application.Models;
using MediatR;

namespace Inventory.Application.Features.Products.GetProducts;

internal sealed record GetProductsStreamQuery : IStreamRequest<ProductModel>;