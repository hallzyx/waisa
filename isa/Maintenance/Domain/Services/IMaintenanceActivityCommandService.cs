using isa.Maintenance.Domain.Model.Aggregates;
using isa.Maintenance.Domain.Model.Commands;

namespace isa.Maintenance.Domain.Services;

public interface IMaintenanceActivityCommandService
{
    Task<MaintenanceActivity?> Handle(CreateMaintenanceActivityCommand command);
}
