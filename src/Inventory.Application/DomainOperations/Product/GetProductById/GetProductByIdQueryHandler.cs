using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.Queries;
using Inventory.Application.Helpers;
using Inventory.Application.Models;
using Inventory.Domain.Products;

namespace Inventory.Application.DomainOperations.Product.GetProductById;

internal sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductModel?>
{
    private readonly IProductsRepository _productsRepository;

    public GetProductByIdQueryHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task<ProductModel?> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await _productsRepository.GetByIdAsync(query.ProductId);

        return product is null
            ? null
            : new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Category = product.Category,
                Description = product.Description,
                ImageSource = await ImageConverter.GetBitmapAsync(product.Picture),
            };
    }
}