using Inventory.Domain.Customers;
using Inventory.Domain.Customers.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.Database.Domain.Customers;

internal class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");

        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Id)
            .HasColumnName(nameof(Customer.Id))
            .ValueGeneratedOnAdd();

        builder.Property(customer => customer.FirstName)
            .HasColumnName(nameof(Customer.FirstName))
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(customer => customer.LastName)
            .HasColumnName(nameof(Customer.LastName))
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(customer => customer.Phone)
            .HasColumnName(nameof(Customer.Phone))
            .HasMaxLength(20)
            .IsRequired();

        builder.OwnsOne(customer => customer.Address, addressBuilder =>
        {
            addressBuilder
                .ToTable("Addresses")
                .Property(address => address.AddressLine1)
                    .HasColumnName(nameof(Address.AddressLine1))
                    .IsRequired();
        });
    }
}