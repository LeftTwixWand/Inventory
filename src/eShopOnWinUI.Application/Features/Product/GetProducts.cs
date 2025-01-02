using System.Runtime.CompilerServices;
using eShopOnWinUI.Application.Models;
using eShopOnWinUI.Domain.Products;
using MediatR;

namespace eShopOnWinUI.Application.Features.Product;

internal sealed record GetProductsStreamQuery : IStreamRequest<ProductModel>;

internal sealed class GetProductsStreamQueryHandler(IProductsRepository productsRepository) : IStreamRequestHandler<GetProductsStreamQuery, ProductModel>
{
    public async IAsyncEnumerable<ProductModel> Handle(GetProductsStreamQuery query, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var product in productsRepository.GetAllAsync(cancellationToken))
        {
            yield return new ProductModel
            {
                Id = product.Id.Value,
                Name = product.Name,
                Category = product.Category,
                ImageSource = product.Image,
            };
        }
    }
}