using isa.Inventory.Domain.Models.Aggregates;
using isa.Shared.Domain.Repositories;

namespace isa.Inventory.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product>
{
    Task<Boolean> ExistsBySerialNumberAsync(string serialNumber);
    
    Task<Product?> GetBySerialNumberAsync(string serialNumber);
}