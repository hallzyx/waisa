using isa.Inventory.Domain.Models.Aggregates;
using isa.Inventory.Domain.Models.Commands;
using isa.Inventory.Domain.Repositories;
using isa.Inventory.Domain.Services;
using isa.Shared.Domain.Repositories;

namespace isa.Inventory.Application.Commands;

public class ProductCommandService(IProductRepository productRepository, IUnitOfWork unitOfWork) : IProductCommandService
{
    public async Task<Product?> Handle(CreateProductCommand command)
    {
        /*if (await productRepository.ExistsBySerialNumberAsync(command.SerialNumber))
        {
            throw new InvalidOperationException("A product with the same serial number already exists.");
        }*/

        var newProduct = new Product(command);
        await productRepository.AddAsync(newProduct);
        await unitOfWork.CompleteAsync();
        return newProduct;
    }
}