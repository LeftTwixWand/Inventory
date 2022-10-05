using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Inventory.Application.Models;
using Inventory.Domain.Products;
using MapsterMapper;
using MediatR;

namespace Inventory.Application.DomainOperations.Product.GetProducts;

internal sealed class GetProductsStreamQueryHandler : IStreamRequestHandler<GetProductsStreamQuery, ProductModel>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IMapper _mapper;

    public GetProductsStreamQueryHandler(IProductsRepository productsRepository, IMapper mapper)
    {
        _productsRepository = productsRepository;
        _mapper = mapper;
    }

    public async IAsyncEnumerable<ProductModel> Handle(GetProductsStreamQuery query, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        await foreach (var product in _productsRepository.GetProductsAsync(cancellationToken))
        {
            yield return _mapper.Map<ProductModel>(product);
        }
    }
}