using System.Threading.Tasks;
using Inventory.Domain.Products;
using Inventory.Domain.Warehouses;

namespace Inventory.Application.Services.Domain;

public interface IWarehouseAccountantService
{
    Task<IWarehouseAccountant> GetActualProductQuantityAccountant(ProductId productId);
}