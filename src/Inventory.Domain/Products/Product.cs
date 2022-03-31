using BuildingBlocks.Domain.Entities;
using Inventory.Domain.Categories;
using Inventory.Domain.Products.Rules;

namespace Inventory.Domain.Products;

public class Product : Entity
{
    private Product(
        int id,
        string name,
        string? description,
        byte[]? picture)
    {
        Id = id;
        Name = name;
        Description = description;
        Picture = picture;
        Category = default!;
    }

    public int Id { get; private set; }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public byte[]? Picture { get; private set; }

    public Category Category { get; private set; }

    public static Product Create(
        string name,
        Category category,
        string? description = default,
        byte[]? picture = default)
    {
        CheckRule(new NameMustNotBeEmptyRyle(name));

        return new Product(0, name, description, picture)
        {
            Category = category,
        };
    }
}