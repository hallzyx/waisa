namespace isa.Maintenance.Domain.Services.External;

public interface IProductContextFacade
{
    Task<bool> ExistProductBySerialNumberAsync(string serialNumber);
}