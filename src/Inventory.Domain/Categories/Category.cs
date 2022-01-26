using BuildingBlocks.Domain.Entities;

namespace Inventory.Domain.Categories;

public class Category : Entity
{
    private Category(int id, string name, string? description, byte[]? picture, byte[]? pictureThumbnail)
    {
        Id = id;
        Name = name;
        Description = description;
        Picture = picture;
        PictureThumbnail = pictureThumbnail;
    }

    public int Id { get; private set; }

    public string Name { get; private set; }

    public string? Description { get; private set; }

    public byte[]? Picture { get; private set; }

    public byte[]? PictureThumbnail { get; private set; }

    public static Category Create(
        string name,
        string? description = default,
        byte[]? picture = default,
        byte[]? pictureThumbnail = default)
    {
        return new Category(0, name, description, picture, pictureThumbnail);
    }
}