using isa.Maintenance.Domain.Model.Aggregates;
using isa.Maintenance.Interfaces.REST.Resources;

namespace isa.Maintenance.Interfaces.REST.Transform;

public static class MaintenanceActivityResourceFromEntityAssembler
{
    public static MaintenanceActivityResource ToResourceFromEntity(MaintenanceActivity entity)
    {
        return new MaintenanceActivityResource(
            entity.Id,
            entity.ProductSerialNumber,
            entity.Summary,
            entity.Description,
            entity.ActivityResult.ToString()
        );
    }
}