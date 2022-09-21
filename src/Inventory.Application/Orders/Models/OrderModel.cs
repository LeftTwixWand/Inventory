using CommunityToolkit.Mvvm.ComponentModel;
using Inventory.Application.Customers.Models;

namespace Inventory.Application.Orders.Models;

public sealed class OrderModel : ObservableObject
{
    internal OrderModel(long orderID, DateTimeOffset orderDate, CustomerModel customer)
    {
        OrderID = orderID;
        OrderDate = orderDate;
        Customer = customer;
    }

    public long OrderID { get; set; }

    public DateTimeOffset OrderDate { get; set; }

    public CustomerModel Customer { get; set; }
}