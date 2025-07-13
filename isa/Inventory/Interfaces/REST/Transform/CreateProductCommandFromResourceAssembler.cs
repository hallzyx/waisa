using isa.Inventory.Domain.Models.Commands;
using isa.Inventory.Interfaces.REST.Resources;

namespace isa.Inventory.Interfaces.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        return new CreateProductCommand(
            resource.Brand,
            resource.Model,
            resource.SerialNumber,
            resource.StatusDescription
        );
    }
}