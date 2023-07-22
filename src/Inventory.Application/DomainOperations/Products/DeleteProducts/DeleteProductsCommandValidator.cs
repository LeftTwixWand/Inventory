using FluentValidation;

namespace Inventory.Application.DomainOperations.Products.DeleteProducts;

internal sealed class DeleteProductsCommandValidator : AbstractValidator<DeleteProductsCommand>
{
    public DeleteProductsCommandValidator()
    {
        RuleFor(command => command.Products)
            .NotNull()
            .NotEmpty();
    }
}