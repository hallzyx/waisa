using isa.Inventory.Domain.Repositories;
using isa.Maintenance.Domain.Services.External;

namespace isa.Maintenance.Infrastructure.ACL.External;

public class ProductContextFacade(IProductRepository productRepository): IProductContextFacade
{
    public async Task<bool> ExistProductBySerialNumberAsync(string serialNumber)
    {
        return await productRepository.ExistsBySerialNumberAsync(serialNumber);
    }
}