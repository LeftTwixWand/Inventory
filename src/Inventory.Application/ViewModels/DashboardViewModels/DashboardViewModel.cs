using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Customers.Models;
using Inventory.Application.Orders.Models;
using Inventory.Application.Products.Models;

namespace Inventory.Application.ViewModels.DashboardViewModels;

public class DashboardViewModel : ObservableObject
{
    public DashboardViewModel()
    {
    }

    public IList<CustomerModel> Customers { get; private set; } = new List<CustomerModel>()
    {
        new CustomerModel() { CustomerID = 1134234234, FirstName = "First", LastName = "LastName", EmailAddress = "wefwegrgergrgwrg@gmail.com" },
        new CustomerModel() { CustomerID = 1134234234, FirstName = "First", LastName = "LastName", EmailAddress = "wefwegrgergrgwrg@gmail.com" },
        new CustomerModel() { CustomerID = 1134234234, FirstName = "First", LastName = "LastName", EmailAddress = "wefwegrgergrgwrg@gmail.com" },
        new CustomerModel() { CustomerID = 1134234234, FirstName = "First", LastName = "LastName", EmailAddress = "wefwegrgergrgwrg@gmail.com" },
        new CustomerModel() { CustomerID = 1134234234, FirstName = "First", LastName = "LastName", EmailAddress = "wefwegrgergrgwrg@gmail.com" },
    };

    public IList<OrderModel> Orders { get; private set; } = new List<OrderModel>()
    {
        new OrderModel(121241241, DateTime.Now, new CustomerModel() { CustomerID = 23234235 }),
        new OrderModel(121241241, DateTime.Now, new CustomerModel() { CustomerID = 23234235 }),
        new OrderModel(121241241, DateTime.Now, new CustomerModel() { CustomerID = 23234235 }),
        new OrderModel(121241241, DateTime.Now, new CustomerModel() { CustomerID = 23234235 }),
        new OrderModel(121241241, DateTime.Now, new CustomerModel() { CustomerID = 23234235 }),
    };

    public IList<ProductModel> Products { get; private set; } = new List<ProductModel>()
    {
        new ProductModel { ProductID = 23423523, Name = "Super mega pro lamp", Price = 9999.990M },
        new ProductModel { ProductID = 23423523, Name = "Super mega pro lamp", Price = 9999.990M },
        new ProductModel { ProductID = 23423523, Name = "Super mega pro lamp", Price = 9999.990M },
        new ProductModel { ProductID = 23423523, Name = "Super mega pro lamp", Price = 9999.990M },
        new ProductModel { ProductID = 23423523, Name = "Super mega pro lamp", Price = 9999.990M },
    };
}