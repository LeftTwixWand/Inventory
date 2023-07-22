using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.CQRS.Commands;
using Inventory.Domain.Orders;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;
using Inventory.Persistence.Database.Repositories;

namespace Inventory.Application.DomainOperations.Products.DeleteProducts;

internal sealed class DeleteProductsCommandHandler : ICommandHandler<DeleteProductsCommand>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IOrdersRepository _ordersRepository;
    private readonly IWarehouseRepository _warehouseRepository;

    public DeleteProductsCommandHandler(IProductsRepository productsRepository, IOrdersRepository ordersRepository, IWarehouseRepository warehouseRepository)
    {
        _productsRepository = productsRepository;
        _ordersRepository = ordersRepository;
        _warehouseRepository = warehouseRepository;
    }

    public async Task Handle(DeleteProductsCommand request, CancellationToken cancellationToken)
    {
        var productIds = request.Products.Select(productModel => new ProductId(productModel.Id)).ToArray();

        var usedProducts = await _ordersRepository.GetListOfUsedProducts(productIds, cancellationToken);
        var warehouses = await _warehouseRepository.GetManyByIdsAsync(usedProducts, cancellationToken);
        foreach (var warehouse in warehouses)
        {
            warehouse.DeactivateProduct();
        }

        var unusedProducts = productIds.Except(usedProducts);
        foreach (var productId in unusedProducts)
        {
            await _productsRepository.DeleteByIdAsync(productId, cancellationToken);
        }
    }
}