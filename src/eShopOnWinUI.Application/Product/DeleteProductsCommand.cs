using eShopOnWinUI.Application.CQRS.Commands;
using eShopOnWinUI.Domain.Documents;
using eShopOnWinUI.Domain.Products;
using FluentValidation;

namespace eShopOnWinUI.Application.Product;

internal sealed record DeleteProductsCommand(ProductId[] ProductIds) : CommandBase;

internal sealed class DeleteProductsCommandValidator : AbstractValidator<DeleteProductsCommand>
{
    public DeleteProductsCommandValidator()
    {
        RuleFor(command => command.ProductIds)
            .NotNull()
            .NotEmpty();
    }
}

internal sealed class DeleteProductsCommandHandler(
    IProductsRepository productsRepository,
    IOrdersRepository ordersRepository,
    IWarehousesRepository warehousesRepository,
    IWarehouseAccountantService warehouseAccountantService)
    : ICommandHandler<DeleteProducts>
{
    public async Task Handle(DeleteProductsCommand command, CancellationToken cancellationToken)
    {
        var productIds = command.ProductIds.Select(productModel => new ProductId(productModel.Id)).ToArray();

        // TODO: Move products deactivation to the domain
        var usedProducts = await ordersRepository.GetListOfUsedProducts(productIds, cancellationToken);
        var warehouses = await warehousesRepository.GetManyByIdAsync(usedProducts, cancellationToken);

        foreach (var warehouse in warehouses)
        {
            var accountant = await warehouseAccountantService.GetActualProductQuantityProjection(warehouse.ProductId, cancellationToken);
            warehouse.DeactivateProduct(accountant, DocumentId.New);
        }

        var unusedProducts = productIds.Except(usedProducts);
        foreach (var productId in unusedProducts)
        {
            await productsRepository.DeleteManyByIdAsync(productId, cancellationToken);
        }
    }
}