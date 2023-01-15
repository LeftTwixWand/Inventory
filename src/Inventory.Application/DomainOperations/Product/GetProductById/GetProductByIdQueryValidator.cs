using FluentValidation;

namespace Inventory.Application.DomainOperations.Product.GetProductById;

internal sealed class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
{
    public GetProductByIdQueryValidator()
    {
        RuleFor(query => query.ProductId).NotEmpty();
    }
}