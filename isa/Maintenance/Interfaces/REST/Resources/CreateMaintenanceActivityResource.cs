using isa.Maintenance.Domain.Model.ValueObjects;

namespace isa.Maintenance.Interfaces.REST.Resources;

public record CreateMaintenanceActivityResource(string ProductSerialNumber, 
                                               string Summary, 
                                               string Description, 
                                               string ActivityResult);

