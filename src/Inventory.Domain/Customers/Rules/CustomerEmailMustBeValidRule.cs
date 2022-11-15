using BuildingBlocks.Domain.BusinessRules;
using CommunityToolkit.Common;

namespace Inventory.Domain.Customers.Rules;

internal sealed record CustomerEmailMustBeValidRule(string Email) : IBusinessRule
{
    public string Message => "Customer email must be valid.";

    public bool BrokenWhen => StringExtensions.IsEmail(Email) is false;
}