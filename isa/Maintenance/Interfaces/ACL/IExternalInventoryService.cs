namespace isa.Maintenance.Interfaces.ACL;

public interface IExternalInventoryService
{
    Task<bool> ProductExistsBySerialNumberAsync(string serialNumber);
    
    Task MatchMaintenanceActivityStatusWithProductStatusAsync(string productSerialNumber, string activityResult);
}