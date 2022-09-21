using Inventory.Application.Products.Models;
using MediatR;

namespace Inventory.Application.Products.GetProducts;

public sealed record GetProductsStream : IStreamRequest<ProductModel>;