using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.CQRS.Queries;
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

        if (product is null)
        {
            return null;
        }

        // TODO: Load product price from some service here
        decimal prodcutPrice = 50;

        // TODO: Use mapping here
        var productModel = new ProductModel
        {
            Id = product.Id,
            Name = product.Name,
            Category = product.Category,
            Description = product.Description,
            Price = prodcutPrice,
            ImageSource = await ImageConverter.GetBitmapAsync(product.Picture),
        };

        return productModel;
    }
}