using BuildingBlocks.Domain.BusinessRules;

namespace Inventory.Domain.OrderItems.Rules;

internal class DiscountCanNotBeMoreThanHundredPercentRule : IBusinessRule
{
    private readonly decimal _discount;

    public DiscountCanNotBeMoreThanHundredPercentRule(decimal discount)
    {
        _discount = discount;
    }

    public string Message => "Discount can not be more than hundred percent!";

    public bool BrokenWhen()
    {
        return _discount > 100;
    }
}
