using isa.Inventory.Domain.Models.Aggregates;
using isa.Inventory.Domain.Repositories;
using isa.Shared.Infrastructure.Persistence.EFC.Configuration;
using isa.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace isa.Inventory.Infrastructure.Persistance.EFC.Repositories;

public class ProductRepository(AppDbContext context): BaseRepository<Product>(context), IProductRepository
{
    public async Task<bool> ExistsBySerialNumberAsync(string serialNumber)
    {
        return await Context.Set<Product>().AnyAsync(c => c.SerialNumber == serialNumber);
    }

    public async Task<Product?> GetBySerialNumberAsync(string serialNumber)
    {
        return await Context.Set<Product>().FirstOrDefaultAsync(c => c.SerialNumber == serialNumber);
    }
}