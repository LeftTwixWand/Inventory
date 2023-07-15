using Inventory.Domain.Products;

namespace Inventory.Domain.Warehouses;

public interface IWarehouseAccountant
{
    int GetActualProductQuantity();
}