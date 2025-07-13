using isa.Inventory.Domain.Models.Aggregates;
using isa.Inventory.Interfaces.REST.Resources;

namespace isa.Inventory.Interfaces.REST.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static CreateProductResource ToResourceFromEntity(Product entity)
    {
        return new CreateProductResource(
            entity.Brand,
            entity.Model,
            entity.SerialNumber,
            entity.StatusDescription
        );
    }
}