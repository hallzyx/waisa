namespace isa.Maintenance.Interfaces.REST.Resources;

public record MaintenanceActivityResource(
    int Id,
    string ProductSerialNumber, 
    string Summary, 
    string Description, 
    string ActivityResult
    );