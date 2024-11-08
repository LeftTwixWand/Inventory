using System.Runtime.CompilerServices;
using MediatR;

namespace eShopOnWinUI.Application.Product;

internal sealed record GetProductsStreamQuery : IStreamRequest<ProductModel>;

internal sealed class GetProductsStreamQueryHandler : IStreamRequestHandler<GetProductsStreamQuery, ProductModel>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductsStreamQueryHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async IAsyncEnumerable<ProductModel> Handle(GetProductsStreamQuery query, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var product in _productsRepository.GetAllAsync(cancellationToken))
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