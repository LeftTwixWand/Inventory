using BuildingBlocks.Domain.AggregateRoots;
using BuildingBlocks.Domain.Entities;
using Inventory.Domain.Customers;
using Inventory.Domain.OrderItems;
using Inventory.Domain.Orders.Enums;
using Inventory.Domain.Orders.Rules;
using Inventory.Domain.Shipments;

namespace Inventory.Domain.Orders;

public class Order : Entity, IAggregateRoot
{
    private readonly List<OrderItem> _orderItems = new();

    private Order(
        int id,
        OrderStatus status,
        DateTimeOffset orderDate,
        PaymentType? paymentType,
        Shipment? shipment)
    {
        Id = id;
        Status = status;
        OrderDate = orderDate;
        PaymentType = paymentType;
        Shipment = shipment;
        Customer = default!;
    }

    public int Id { get; private set; }

    public OrderStatus Status { get; private set; }

    public DateTimeOffset OrderDate { get; set; }

    public PaymentType? PaymentType { get; private set; }

    public Shipment? Shipment { get; private set; }

    public Customer Customer { get; private set; }

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public static Order Create(
        OrderStatus status,
        DateTimeOffset orderDate,
        Customer customer,
        Shipment? shipment,
        PaymentType? paymentType = default,
        params OrderItem[] orderItems)
    {
        // CheckRule(new ShippingInformationCanNotBeEmptyRule(shipAddress, shipCity, shipRegion, shipCountryCode, shipPostalCode));

        var order = new Order(0, status, orderDate, paymentType, shipment)
        {
            Customer = customer,
        };

        order._orderItems.AddRange(orderItems);

        return order;
    }
}