using isa.Inventory.Domain.Models.Aggregates;
using isa.Inventory.Domain.Models.Queries;

namespace isa.Inventory.Domain.Services;

public interface IProductQueryService
{
    Task<Product?> Handle(GetProductByIdQuery query);
}
