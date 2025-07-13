namespace isa.Inventory.Interfaces.ACL;

public interface IInventoryContextFacade
{
    Task<bool> ProductExistsBySerialNumberAsync(string serialNumber);
    
    Task MatchMaintenanceActivityStatusWithProductStatusAsync(string productSerialNumber, string activityResult);
}