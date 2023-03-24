using FluentValidation;

namespace Inventory.Application.DomainOperations.Product.DeleteProducts;

internal sealed class DeleteProductsCommandValidator : AbstractValidator<DeleteProductsCommand>
{
    public DeleteProductsCommandValidator()
    {
        RuleFor(command => command.Products)
            .NotNull()
            .NotEmpty();
    }
}