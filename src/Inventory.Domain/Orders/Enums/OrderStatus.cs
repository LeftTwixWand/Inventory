namespace Inventory.Domain.Orders.Enums;

public enum OrderStatus : byte
{
    Pending,
    Processing,
    Shipped,
    Delivered,
}