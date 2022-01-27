using BuildingBlocks.Domain.AggregateRoots;
using BuildingBlocks.Domain.Entities;
using Inventory.Domain.Customers;
using Inventory.Domain.OrderItems;
using Inventory.Domain.Orders.Enums;
using Inventory.Domain.Orders.Rules;

namespace Inventory.Domain.Orders;

public class Order : Entity, IAggregateRoot
{
    private readonly List<OrderItem> _orderItems = new();

    public Order(
        int id,
        string shipAddress,
        string shipCity,
        string shipRegion,
        string shipCountryCode,
        string shipPostalCode,
        OrderStatus status,
        DateTimeOffset orderDate,
        PaymentType? paymentType,
        DateTimeOffset? shippedDate,
        DateTimeOffset? deliveredDate)
    {
        Id = id;
        ShipAddress = shipAddress;
        ShipCity = shipCity;
        ShipRegion = shipRegion;
        ShipCountryCode = shipCountryCode;
        ShipPostalCode = shipPostalCode;
        Status = status;
        OrderDate = orderDate;
        PaymentType = paymentType;
        ShippedDate = shippedDate;
        DeliveredDate = deliveredDate;
        Customer = default!;
    }

    public int Id { get; private set; }

    public string ShipAddress { get; private set; }

    public string ShipCity { get; private set; }

    public string ShipRegion { get; private set; }

    public string ShipCountryCode { get; private set; }

    public string ShipPostalCode { get; private set; }

    public OrderStatus Status { get; private set; }

    public DateTimeOffset OrderDate { get; set; }

    public PaymentType? PaymentType { get; private set; }

    public DateTimeOffset? ShippedDate { get; set; }

    public DateTimeOffset? DeliveredDate { get; set; }

    public Customer Customer { get; private set; }

    public IReadOnlyCollection<OrderItem> OrderItems
    {
        get => _orderItems;
    }

    public static Order Create(
        string shipAddress,
        string shipCity,
        string shipRegion,
        string shipCountryCode,
        string shipPostalCode,
        OrderStatus status,
        DateTimeOffset orderDate,
        Customer customer,
        IEnumerable<OrderItem> orderItems,
        PaymentType? paymentType = default,
        DateTimeOffset? shippedDate = default,
        DateTimeOffset? deliveredDate = default)
    {
        CheckRule(new ShippingInformationCanNotBeEmptyRule(shipAddress, shipCity, shipRegion, shipCountryCode, shipPostalCode));

        var order = new Order(0, shipAddress, shipCity, shipRegion, shipCountryCode, shipPostalCode, status, orderDate, paymentType, shippedDate, deliveredDate)
        {
            Customer = customer,
        };

        order.SetOrderItems(orderItems);

        return order;
    }

    public void SetOrderItems(IEnumerable<OrderItem> orderItems)
    {
        _orderItems.Clear();
        _orderItems.AddRange(orderItems);
    }
}