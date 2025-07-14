using isa.Inventory.Domain.Repositories;
using isa.Inventory.Interfaces.ACL;
using isa.Shared.Domain.Repositories;

namespace isa.Inventory.Application.ACL;

public class InventoryContextFacade(IProductRepository productRepository, IUnitOfWork unitOfWork) : IInventoryContextFacade
{
    public async Task<bool> ProductExistsBySerialNumberAsync(string serialNumber)
    {
        return await productRepository.ExistsBySerialNumberAsync(serialNumber);
    }

    public async Task MatchMaintenanceActivityStatusWithProductStatusAsync(string productSerialNumber, string activityResult)
    {
        var certainProduct = await productRepository.GetBySerialNumberAsync(productSerialNumber);
        if (certainProduct is null)
            throw new Exception($"Product {productSerialNumber} not found");

        
        if (activityResult.Equals("PRODUCT_STILL_UNOPERATIONAL") || activityResult == "0")
        {
            certainProduct.SetStatus("UNOPERATIONAL");
            await unitOfWork.CompleteAsync();

        }
        else if (activityResult.Equals("PRODUCT_IS_OPERATIONAL") || activityResult == "1")
        {
            certainProduct.SetStatus("OPERATIONAL");
            await unitOfWork.CompleteAsync();
        }
        else
        {
            throw new ArgumentException($"Invalid activity result: {activityResult}");
        }
        
    }
}