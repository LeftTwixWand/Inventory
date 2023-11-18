using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Application.CQRS.Commands;
using Inventory.Application.Services.Domain;
using Inventory.Domain.Documents;
using Inventory.Domain.Orders;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;

namespace Inventory.Application.DomainOperations.Products.DeleteProducts;

internal sealed class DeleteProductsCommandHandler : ICommandHandler<DeleteProductsCommand>
{
    private readonly IProductsRepository _productsRepository;
    private readonly IOrdersRepository _ordersRepository;
    private readonly IWarehousesRepository _warehousesRepository;
    private readonly IWarehouseAccountantService _warehouseAccountantService;

    public DeleteProductsCommandHandler(IProductsRepository productsRepository, IOrdersRepository ordersRepository, IWarehousesRepository warehouseRepository, IWarehouseAccountantService warehouseAccountantService)
    {
        _productsRepository = productsRepository;
        _ordersRepository = ordersRepository;
        _warehousesRepository = warehouseRepository;
        _warehouseAccountantService = warehouseAccountantService;
    }

    public async Task Handle(DeleteProductsCommand command, CancellationToken cancellationToken)
    {
        var productIds = command.Products.Select(productModel => new ProductId(productModel.Id)).ToArray();

        var usedProducts = await _ordersRepository.GetListOfUsedProducts(productIds, cancellationToken);
        var warehouses = await _warehousesRepository.GetManyByIdAsync(usedProducts, cancellationToken);

        foreach (var warehouse in warehouses)
        {
            var accountant = await _warehouseAccountantService.GetActualProductQuantityAccountant(warehouse.ProductId, cancellationToken);
            warehouse.DeactivateProduct(accountant, DocumentId.New);
        }

        var unusedProducts = productIds.Except(usedProducts);
        foreach (var productId in unusedProducts)
        {
            await _productsRepository.DeleteManyByIdAsync(productId, cancellationToken);
        }
    }
}