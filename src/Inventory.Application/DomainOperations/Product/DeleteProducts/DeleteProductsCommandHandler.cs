using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.CQRS.Commands;
using Inventory.Domain.Products;

namespace Inventory.Application.DomainOperations.Product.DeleteProducts;

internal sealed class DeleteProductsCommandHandler : ICommandHandler<DeleteProductsCommand>
{
    private readonly IProductsRepository _productsRepository;

    public DeleteProductsCommandHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public async Task Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
    {
        foreach (var product in request.Products)
        {
            await _productsRepository.DeleteByIdAsync(product.Id, cancellationToken);
        }
    }
}