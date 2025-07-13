using isa.Inventory.Interfaces.ACL;
using isa.Maintenance.Interfaces.ACL;

namespace isa.Maintenance.Application.OutBoundServices.ACL;

public class ExternalInventoryService(IInventoryContextFacade inventoryContextFacade):IExternalInventoryService
{
    public async Task<bool> ProductExistsBySerialNumberAsync(string serialNumber)
    {
        return await inventoryContextFacade.ProductExistsBySerialNumberAsync(serialNumber);
    }

    public async Task MatchMaintenanceActivityStatusWithProductStatusAsync(string productSerialNumber, string activityResult)
    {
        await inventoryContextFacade.MatchMaintenanceActivityStatusWithProductStatusAsync(productSerialNumber, activityResult);
    }
}