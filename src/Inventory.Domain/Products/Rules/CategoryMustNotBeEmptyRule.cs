using BuildingBlocks.Domain.BusinessRules;

namespace Inventory.Domain.Products.Rules;

internal sealed record CategoryMustNotBeEmptyRule(string Category) : IBusinessRule
{
    public string Message => "Product name must not be empty.";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(Category);
}