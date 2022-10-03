using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Domain.Products;
using MediatR;

namespace Inventory.Application.DomainOperations.Product.GetProducts;

internal sealed record GetProductsStreamQuery : IStreamRequest<ProductModel>;

internal sealed class GetProductsStreamQueryHandler : IStreamRequestHandler<GetProductsStream, ProductModel>
{
    private readonly IProductsRepository _repository;

    public GetProductsStreamQueryHandler(IProductsRepository repository)
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