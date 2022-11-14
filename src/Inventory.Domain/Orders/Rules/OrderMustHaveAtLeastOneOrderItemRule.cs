using BuildingBlocks.Domain.BusinessRules;
using Inventory.Domain.OrderItems;

namespace Inventory.Domain.Orders.Rules;

internal sealed record OrderMustHaveAtLeastOneOrderItemRule(OrderItem[] OrderItems) : IBusinessRule
{
    public string Message => "Order must have at least one order item.";

    public bool BrokenWhen => OrderItems.Length < 1;
}