using BuildingBlocks.Domain.BusinessRules;

namespace Inventory.Domain.Products.Rules;

internal class CategoryMustNotBeEmptyRule : IBusinessRule
{
    private readonly string _category;

    public CategoryMustNotBeEmptyRule(string category)
    {
        _category = category;
    }

    public string Message => "Product name must not be empty!";

    public bool BrokenWhen()
    {
        return string.IsNullOrEmpty(_category);
    }
}