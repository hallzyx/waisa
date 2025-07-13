using isa.Maintenance.Domain.Model.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace isa.Maintenance.Infrastructure.Persistance.EFC.Configuration;

public static class ModelBuilderExtensions
{
    public static void ApplyMaintenanceActivityConfiguration(this ModelBuilder builder)
    {
        builder.Entity<MaintenanceActivity>().HasKey(c => c.Id);
        builder.Entity<MaintenanceActivity>().Property(c => c.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Entity<MaintenanceActivity>().Property(c => c.ProductSerialNumber).IsRequired().HasMaxLength(100);
        builder.Entity<MaintenanceActivity>().Property(c => c.Summary).IsRequired().HasMaxLength(200);
        builder.Entity<MaintenanceActivity>().Property(c => c.Description).IsRequired().HasMaxLength(500);
        builder.Entity<MaintenanceActivity>().Property(c => c.ActivityResult).IsRequired().HasConversion<int>();
    }
}