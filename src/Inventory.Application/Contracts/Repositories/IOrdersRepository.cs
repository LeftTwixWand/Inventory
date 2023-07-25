using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Inventory.Domain.Products;

namespace Inventory.Application.Contracts.Repositories;

public interface IOrdersRepository
{
    Task<List<ProductId>> GetListOfUsedProducts(ProductId[] products, CancellationToken cancellationToken);
}