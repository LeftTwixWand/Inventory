using BuildingBlocks.Domain.AggregateRoots;
using BuildingBlocks.Domain.Entities;
using Inventory.Domain.Customers;
using Inventory.Domain.OrderItems;
using Inventory.Domain.Shipments;

namespace Inventory.Domain.Orders;

public class Order : Entity, IAggregateRoot
{
    private readonly List<OrderItem> _orderItems = new();

    private Order(int id, DateTimeOffset orderDate, PaymentType? paymentType, Shipment? shipment)
    {
        Id = id;
        OrderDate = orderDate;
        PaymentType = paymentType;
        Shipment = shipment;
        Customer = default!;
    }

    public int Id { get; private set; }

    public DateTimeOffset OrderDate { get; set; }

    public PaymentType? PaymentType { get; private set; }

    public Shipment? Shipment { get; private set; }

    public Customer Customer { get; private set; }

    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly();

    public static Order Create(DateTimeOffset orderDate, Customer customer, Shipment? shipment, PaymentType? paymentType = default, params OrderItem[] orderItems)
    {
        var order = new Order(0, orderDate, paymentType, shipment)
        {
            Customer = customer,
        };

        order._orderItems.AddRange(orderItems);

        return order;
    }
}