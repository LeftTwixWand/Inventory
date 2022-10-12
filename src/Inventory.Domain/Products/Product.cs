using BuildingBlocks.Domain.Entities;
using Inventory.Domain.Products.Rules;

namespace Inventory.Domain.Products;

public class Product : Entity
{
    private Product(
        int id,
        string name,
        string category,
        string? description,
        byte[]? picture)
    {
        Id = id;
        Name = name;
        Description = description;
        Category = category;
        Picture = picture;
    }

    public int Id { get; private set; }

    public string Name { get; private set; }

    public string Category { get; private set; }

    public string? Description { get; private set; }

    public byte[]? Picture { get; private set; }

    public static Product Create(
        string name,
        string category,
        string? description = default,
        byte[]? picture = default)
    {
        CheckRule(new NameMustNotBeEmptyRule(name));
        CheckRule(new CategoryMustNotBeEmptyRule(name));

        return new Product(0, name, category, description, picture);
    }
}