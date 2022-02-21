using System.Runtime.CompilerServices;
using HarabaSourceGenerators.Common.Attributes;
using Inventory.Application.Products.Models;
using Inventory.Domain.Products;
using Mapster;
using MediatR;

namespace Inventory.Application.Products.GetProducts;

[Inject]
public partial class GetProductsStreamHandler : IStreamRequestHandler<GetProductsStream, ProductModel>
{
    private readonly IProductsRepository _repository;

    public async IAsyncEnumerable<ProductModel> Handle(GetProductsStream request, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var item in _repository.GetProductsAsync())
        {
            yield return item.Adapt<ProductModel>();
        }
    }
}