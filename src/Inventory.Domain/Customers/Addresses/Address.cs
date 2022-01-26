using BuildingBlocks.Domain.ValueObjects;

namespace Inventory.Domain.Customers.Addresses;

public record Address : ValueObject
{
    public Address(string addressLine1, string city, string region, string countryCode, string postalCode, string? addressLine2 = default)
    {
        AddressLine1 = addressLine1;
        AddressLine2 = addressLine2;
        City = city;
        Region = region;
        CountryCode = countryCode;
        PostalCode = postalCode;
    }

    public string AddressLine1 { get; private set; }

    public string? AddressLine2 { get; private set; }

    public string City { get; private set; }

    public string Region { get; private set; }

    public string CountryCode { get; private set; }

    public string PostalCode { get; private set; }
}