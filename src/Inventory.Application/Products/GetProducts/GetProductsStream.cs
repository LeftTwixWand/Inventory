using Inventory.Application.Products.Models;
using MediatR;

namespace Inventory.Application.Products.GetProducts;

public record GetProductsStream : IStreamRequest<ProductModel>;