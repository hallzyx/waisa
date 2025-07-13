using isa.Inventory.Domain.Models.Aggregates;
using isa.Inventory.Domain.Models.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace isa.Inventory.Infrastructure.Persistance.EFC.Configuration;

public static class ModelBuilderExtensions
{
    public static void ApplyProductConfiguration(this ModelBuilder builder)
    {
        builder.Entity<Product>().HasKey(c => c.Id);
        builder.Entity<Product>().Property(c => c.Id).ValueGeneratedOnAdd().IsRequired();
        builder.Entity<Product>().Property(c => c.Brand).IsRequired();
        builder.Entity<Product>().Property(c => c.Model).IsRequired();
        builder.Entity<Product>().Property(c => c.SerialNumber).IsRequired();
        builder.Entity<Product>().Property(c => c.Status).HasConversion<int>();
        builder.Entity<Product>().Ignore(c => c.StatusDescription);
        ;
    }
}