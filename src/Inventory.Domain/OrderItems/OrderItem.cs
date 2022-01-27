using BuildingBlocks.Domain.Entities;
using Inventory.Domain.OrderItems.Rules;
using Inventory.Domain.Products;

namespace Inventory.Domain.OrderItems;

public class OrderItem : Entity
{
    private OrderItem(int id, int quantity, decimal unitPrice, decimal discount)
    {
        Id = id;
        Quantity = quantity;
        UnitPrice = unitPrice;
        Discount = discount;
        Product = default!;
    }

    public int Id { get; private set; }

    public int Quantity { get; private set; }

    public decimal UnitPrice { get; private set; }

    public decimal Discount { get; private set; }

    public Product Product { get; private set; }

    public static OrderItem Create(Product product, int quantity, decimal unitPrice, decimal discount = 0)
    {
        CheckRule(new DiscountCanNotBeMoreThanHundredPercentRule(discount));

        return new OrderItem(0, quantity, unitPrice, discount)
        {
            Product = product,
        };
    }
}