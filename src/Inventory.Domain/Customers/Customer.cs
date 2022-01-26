using BuildingBlocks.Domain.Entities;
using Inventory.Domain.Customers.Addresses;

namespace Inventory.Domain.Customers;

public class Customer : Entity
{
    public Customer(
        int id,
        string firstName,
        string lastName,
        string phone,
        string emailAddress,
        string? middleName = default,
        string? suffix = default,
        string? title = default,
        byte[]? picture = default,
        byte[]? thumbnail = default)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Suffix = suffix;
        Title = title;
        Phone = phone;
        EmailAddress = emailAddress;
        Address = default!;
        Picture = picture;
        Thumbnail = thumbnail;
    }

    public int Id { get; private set; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string? MiddleName { get; private set; }

    public string? Suffix { get; private set; }

    public string? Title { get; private set; }

    public string Phone { get; private set; }

    public string EmailAddress { get; private set; }

    public Address Address { get; private set; }

    public byte[]? Picture { get; set; }

    public byte[]? Thumbnail { get; set; }

    public static Customer Create(
        string firstName,
        string lastName,
        string phone,
        string emailAddress,
        Address address,
        string? middleName = default,
        string? suffix = default,
        string? title = default,
        byte[]? picture = default,
        byte[]? thumbnail = default)
    {
        return new Customer(0, firstName, lastName, phone, emailAddress, middleName, suffix, title, picture, thumbnail)
        {
            Address = address,
        };
    }
}