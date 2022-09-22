using BuildingBlocks.Domain.BusinessRules;

namespace Inventory.Domain.Orders.Rules;

internal class ShippingInformationCanNotBeEmptyRule : IBusinessRule
{
    private readonly string _shipAddress;
    private readonly string _shipCity;
    private readonly string _shipRegion;
    private readonly string _shipCountryCode;
    private readonly string _shipPostalCode;

    public ShippingInformationCanNotBeEmptyRule(string shipAddress, string shipCity, string shipRegion, string shipCountryCode, string shipPostalCode)
    {
        _shipAddress = shipAddress;
        _shipCity = shipCity;
        _shipRegion = shipRegion;
        _shipCountryCode = shipCountryCode;
        _shipPostalCode = shipPostalCode;
    }

    public string Message => "Shipping information must be filled correct!";

    public bool BrokenWhen()
    {
        return string.IsNullOrEmpty(_shipAddress)
            || string.IsNullOrEmpty(_shipCity)
            || string.IsNullOrEmpty(_shipRegion)
            || string.IsNullOrEmpty(_shipCountryCode)
            || string.IsNullOrEmpty(_shipPostalCode);
    }
}