using isa.Maintenance.Domain.Model.Aggregates;
using isa.Maintenance.Domain.Repositories;
using isa.Shared.Infrastructure.Persistence.EFC.Configuration;
using isa.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace isa.Maintenance.Infrastructure.Persistance.EFC.Repositories;

public class MaintenanceActivityRepository(AppDbContext context):  BaseRepository<MaintenanceActivity>(context), IMaintenanceActivityRepository
{
    
}