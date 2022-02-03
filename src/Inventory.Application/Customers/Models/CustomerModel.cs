using CommunityToolkit.Mvvm.ComponentModel;

namespace Inventory.Application.Customers.Models;

public class CustomerModel : ObservableObject
{
    public long CustomerID { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string EmailAddress { get; set; } = string.Empty;

    public object? ThumbnailSource { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}