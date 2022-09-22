using BuildingBlocks.Domain.Entities;
using Inventory.Domain.Categories;
using Inventory.Domain.Products.Rules;

namespace Inventory.Domain.Products;

public class Product : Entity
{
    private Product(
        int id,
        string name,
        decimal listPrice,
        decimal dealerPrice,
        decimal discount,
        string? description,
        byte[]? picture)
    {
        Id = id;
        Name = name;
        Description = description;
        ListPrice = listPrice;
        DealerPrice = dealerPrice;
        Discount = discount;
        Picture = picture;
        Category = default!;
    }

    public int Id { get; private set; }

    public string Name { get; private set; }

    public decimal ListPrice { get; private set; }

    public decimal DealerPrice { get; private set; }

    public decimal Discount { get; set; }

    public string? Description { get; private set; }

    public byte[]? Picture { get; private set; }

    public Category Category { get; private set; }

    public static Product Create(
        string name,
        decimal listPrice,
        decimal dealerPrice,
        Category category,
        decimal discount = 0,
        string? description = default,
        byte[]? picture = default)
    {
        CheckRule(new NameMustNotBeEmptyRyle(name));

        return new Product(0, name, listPrice, dealerPrice, discount, description, picture)
        {
            Category = category,
        };
    }
}