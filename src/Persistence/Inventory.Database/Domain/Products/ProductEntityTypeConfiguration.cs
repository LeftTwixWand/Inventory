using Inventory.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Database.Domain.Products;

internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(product => product.Id);

        builder.Property(product => product.Id)
            .HasColumnName(nameof(Product.Id))
            .ValueGeneratedOnAdd();

        builder.Property(product => product.Name)
            .HasColumnName(nameof(Product.Name))
            .HasMaxLength(55)
            .IsRequired();
    }
}