
using isa.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using isa.Inventory.Infrastructure.Persistance.EFC.Configuration;
using isa.Maintenance.Infrastructure.Persistance.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace isa.Shared.Infrastructure.Persistence.EFC.Configuration;

/// <summary>
///     Application database context
/// </summary>
public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        // Add the created and updated interceptor
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

       builder.ApplyProductConfiguration();
       builder.ApplyMaintenanceActivityConfiguration();

        builder.UseSnakeCaseNamingConvention();
    }
}