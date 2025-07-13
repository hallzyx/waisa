using isa.Maintenance.Domain.Model.Aggregates;
using isa.Maintenance.Domain.Model.Commands;
using isa.Maintenance.Domain.Repositories;
using isa.Maintenance.Domain.Services;
using isa.Maintenance.Interfaces.ACL;
using isa.Shared.Domain.Repositories;

namespace isa.Maintenance.Application.Commands;

public class MaintenanceActivityCommandService(IMaintenanceActivityRepository maintenanceActivityRepository, IUnitOfWork unitOfWork, IExternalInventoryService externalInventoryService) : IMaintenanceActivityCommandService
{
    public async Task<MaintenanceActivity?> Handle(CreateMaintenanceActivityCommand command)
    {
        
        if (!await externalInventoryService.ProductExistsBySerialNumberAsync(command.ProductSerialNumber))
        {
            throw new ArgumentException($"Product with serial number {command.ProductSerialNumber} does not exist. Is not possible to create a maintenance activity for a non-existing product.", nameof(command.ProductSerialNumber));
        }
        
        var newMaintenanceActivity = new MaintenanceActivity(command);
        await maintenanceActivityRepository.AddAsync(newMaintenanceActivity);
        await externalInventoryService.MatchMaintenanceActivityStatusWithProductStatusAsync(command.ProductSerialNumber,
            command.ActivityResult);
        await unitOfWork.CompleteAsync();
        return newMaintenanceActivity;
    }
}
