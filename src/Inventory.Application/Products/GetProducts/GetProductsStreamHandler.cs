using System.Runtime.CompilerServices;
using Inventory.Application.Products.Models;
using Inventory.Domain.Products;
using Mapster;
using MediatR;

namespace Inventory.Application.Products.GetProducts;

public sealed class GetProductsStreamHandler : IStreamRequestHandler<GetProductsStream, ProductModel>
{
    private readonly IProductsRepository _repository;

    public GetProductsStreamHandler(IProductsRepository repository)
    {
        _repository = repository;
    }

    public async IAsyncEnumerable<ProductModel> Handle(GetProductsStream request, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var item in _repository.GetProductsAsync())
        {
            yield return item.Adapt<ProductModel>();
        }
    }
}