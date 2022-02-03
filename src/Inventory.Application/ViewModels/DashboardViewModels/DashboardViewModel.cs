using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Customers.Models;

namespace Inventory.Application.ViewModels.DashboardViewModels;

public class DashboardViewModel : ObservableObject
{
    public DashboardViewModel()
    {
    }

    public IList<CustomerModel> Customers { get; private set; } = new List<CustomerModel>()
    {
        new CustomerModel() { CustomerID = 1, FirstName = "First", LastName = "LastName", EmailAddress = "wefwegrgergrgwrg@gmail.com" },
        new CustomerModel() { CustomerID = 1, FirstName = "First", LastName = "LastName", EmailAddress = "wefwegrgergrgwrg@gmail.com" },
        new CustomerModel() { CustomerID = 1, FirstName = "First", LastName = "LastName", EmailAddress = "wefwegrgergrgwrg@gmail.com" },
        new CustomerModel() { CustomerID = 1, FirstName = "First", LastName = "LastName", EmailAddress = "wefwegrgergrgwrg@gmail.com" },
        new CustomerModel() { CustomerID = 1, FirstName = "First", LastName = "LastName", EmailAddress = "wefwegrgergrgwrg@gmail.com" },
    };
}