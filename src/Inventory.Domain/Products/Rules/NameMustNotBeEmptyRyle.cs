using BuildingBlocks.Domain.BusinessRules;

namespace Inventory.Domain.Products.Rules;

internal class NameMustNotBeEmptyRyle : IBusinessRule
{
    private readonly string _name;

    public NameMustNotBeEmptyRyle(string name)
    {
        _name = name;
    }

    public string Message => "Product name must not be empty!";

    public bool BrokenWhen()
    {
        return string.IsNullOrEmpty(_name);
    }
}