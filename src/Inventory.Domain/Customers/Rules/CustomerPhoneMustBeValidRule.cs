using BuildingBlocks.Domain.BusinessRules;
using CommunityToolkit.Common;

namespace Inventory.Domain.Customers.Rules;

internal sealed record CustomerPhoneMustBeValidRule(string Phone) : IBusinessRule
{
    public string Message => "Customer phone number must be valid.";

    public bool BrokenWhen => StringExtensions.IsPhoneNumber(Phone) is false;
}