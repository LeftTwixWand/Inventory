using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Inventory.Application.Helpers;
using Inventory.Application.Models;
using Inventory.Domain.Products;
using MediatR;

namespace Inventory.Application.DomainOperations.Product.GetProducts;

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
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                ImageSource = await ImageConverter.GetBitmapAsync(product.Picture),
            };
        }
    }
}