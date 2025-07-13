using isa.Inventory.Domain.Models.Aggregates;
using isa.Inventory.Domain.Models.Commands;

namespace isa.Inventory.Domain.Services;

public interface IProductCommandService
{
    Task<Product?> Handle(CreateProductCommand command);
}