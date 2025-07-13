using isa.Maintenance.Domain.Model.Commands;
using isa.Maintenance.Interfaces.REST.Resources;

namespace isa.Maintenance.Interfaces.REST.Transform;

public static class CreateMaintenanceActivityCommandFromResourceAssembler
{
    public static CreateMaintenanceActivityCommand ToCommandFromResource(
        CreateMaintenanceActivityResource resource)
    {
        return new CreateMaintenanceActivityCommand(
            resource.ProductSerialNumber,
            resource.Summary,
            resource.Description,
            resource.ActivityResult
        );
    }
}