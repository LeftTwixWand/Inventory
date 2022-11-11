using BuildingBlocks.Domain.ValueObjects;

namespace Inventory.Domain.Shipments;

public record Shipment : ValueObject
{
    private Shipment(string address, string city, string region, Country country, string postalCode, DateTimeOffset? shippedDate, DateTimeOffset? deliveredDate)
    {
        Address = address;
        City = city;
        Region = region;
        Country = country;
        PostalCode = postalCode;
        ShippedDate = shippedDate;
        DeliveredDate = deliveredDate;
    }

    public string Address { get; private set; }

    public string City { get; private set; }

    public string Region { get; private set; }

    public Country Country { get; private set; }

    public string PostalCode { get; private set; }

    public Status Status { get; set; }

    public DateTimeOffset? ShippedDate { get; private set; }

    public DateTimeOffset? DeliveredDate { get; private set; }

    public static Shipment Create(string address, string city, string region, Country country, string postalCode, DateTimeOffset? shippedDate = default, DateTimeOffset? deliveredDate = default)
    {
        return new Shipment(address, city, region, country, postalCode, shippedDate, deliveredDate);
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