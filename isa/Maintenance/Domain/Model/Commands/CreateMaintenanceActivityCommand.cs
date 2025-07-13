using isa.Maintenance.Domain.Model.ValueObjects;

namespace isa.Maintenance.Domain.Model.Commands;

public record CreateMaintenanceActivityCommand(string ProductSerialNumber,
                                              string Summary,
                                              string Description,
                                              string ActivityResult);


