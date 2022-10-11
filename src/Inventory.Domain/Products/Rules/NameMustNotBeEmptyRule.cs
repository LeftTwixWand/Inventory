using BuildingBlocks.Domain.BusinessRules;

namespace Inventory.Domain.Products.Rules;

internal class NameMustNotBeEmptyRule : IBusinessRule
{
    private readonly string _name;

    public NameMustNotBeEmptyRule(string name)
    {
        _name = name;
    }

    public string Message => "Product name must not be empty!";

    public bool BrokenWhen()
    {
        return string.IsNullOrEmpty(_name);
    }
}