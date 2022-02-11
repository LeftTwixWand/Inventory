using Inventory.Domain.Orders;
using Inventory.Domain.Orders.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Inventory.Database.Domain.Orders;

internal class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(order => order.Id);

        builder.Property(order => order.Id)
            .HasColumnName(nameof(Order.Id))
            .ValueGeneratedOnAdd();

        builder.Property(order => order.PaymentType)
            .HasColumnName(nameof(Order.PaymentType))
            .HasConversion(new EnumToNumberConverter<PaymentType, byte>());
    }
}