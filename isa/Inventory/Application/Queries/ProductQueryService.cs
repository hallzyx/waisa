using isa.Inventory.Domain.Models.Aggregates;
using isa.Inventory.Domain.Models.Queries;
using isa.Inventory.Domain.Repositories;
using isa.Inventory.Domain.Services;

namespace isa.Inventory.Application.Queries;

public class ProductQueryService(IProductRepository productRepository) : IProductQueryService
{
    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        var certainProduct = await productRepository.FindByIdAsync(query.Id);
        if (certainProduct == null)
        {
            throw new InvalidOperationException($"Product with ID {query.Id} not found.");
        }

        return certainProduct;
    }
}