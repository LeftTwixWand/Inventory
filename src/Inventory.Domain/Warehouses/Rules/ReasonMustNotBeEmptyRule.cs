using BuildingBlocks.Domain.BusinessRules;

namespace Inventory.Domain.Warehouses.Rules;

internal sealed record ReasonMustNotBeEmptyRule(string Reason) : IBusinessRule
{
    public string Message => "Products missing reason must not be empty.";

    public bool BrokenWhen => string.IsNullOrWhiteSpace(Reason);
}