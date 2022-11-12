using BuildingBlocks.Domain.ValueObjects;
using Inventory.Domain.Shipments.Rules;

namespace Inventory.Domain.Shipments;

public record Shipment : ValueObject
{
    private Shipment(string address, string city, string region, Country country, string postalCode, Status status, DateTimeOffset? shippedDate, DateTimeOffset? deliveredDate)
    {
        Address = address;
        City = city;
        Region = region;
        Country = country;
        PostalCode = postalCode;
        Status = status;
        ShippedDate = shippedDate;
        DeliveredDate = deliveredDate;
    }

    public string Address { get; private set; }

    public string City { get; private set; }

    public string Region { get; private set; }

    public Country Country { get; private set; }

    public string PostalCode { get; private set; }

    public Status Status { get; set; } = Status.Processing;

    public DateTimeOffset? ShippedDate { get; private set; }

    public DateTimeOffset? DeliveredDate { get; private set; }

    public static Shipment Create(string address, string city, string region, Country country, string postalCode, DateTimeOffset? shippedDate = default, DateTimeOffset? deliveredDate = default)
    {
        CheckRule(new ShipmentAddressMustNotBeEmptyRule(address));
        CheckRule(new ShipmentCityMustNotBeEmptyRule(city));
        CheckRule(new ShipmentRegionMustNotBeEmptyRule(region));
        CheckRule(new ShipmentPostalCodeMustNotBeEmptyRule(postalCode));
        CheckRule(new ShipmentPostalCodeMustContainsOnlyNumbersRule(postalCode));

        return new Shipment(address, city, region, country, postalCode, Status.Processing, shippedDate, deliveredDate);
    }

    public void Ship(DateTimeOffset shippedDate)
    {
        Status = Status.Shipped;
        ShippedDate = shippedDate;
    }

    public void Deviver(DateTimeOffset deliveredDate)
    {
        Status = Status.Delivered;
        DeliveredDate = deliveredDate;
    }
}