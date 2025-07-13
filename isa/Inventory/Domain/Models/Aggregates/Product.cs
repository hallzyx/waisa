using isa.Inventory.Domain.Models.Commands;
using isa.Inventory.Domain.Models.ValueObjects;

namespace isa.Inventory.Domain.Models.Aggregates;

public class Product
{
    public int Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string SerialNumber { get; set; }
    public EStatus Status { get; set; }
    public string StatusDescription => Status switch
    {
        EStatus.OPERATIONAL => "OPERATIONAL",
        EStatus.UNOPERATIONAL => "UNOPERATIONAL",
        _ => throw new ArgumentOutOfRangeException(nameof(Status), $"Status {Status} is not valid.")
    };
    
    public Product(){}

    public Product(CreateProductCommand command)
    { 
        if(string.IsNullOrWhiteSpace(command.Brand))
            throw new ArgumentException("Brand cannot be empty.", nameof(command.Brand));
        if(string.IsNullOrWhiteSpace(command.Model))
            throw new ArgumentException("Model cannot be empty.", nameof(command.Model));
        if(string.IsNullOrWhiteSpace(command.SerialNumber))
            throw new ArgumentException("Serial number cannot be empty.", nameof(command.SerialNumber));
        
        Brand = command.Brand;
        Model = command.Model;
        SerialNumber = command.SerialNumber;
        SetStatus(command.StatusDescription);
        
    }

    public void SetStatus(string statusDescription)
    {
        if (string.IsNullOrWhiteSpace(statusDescription))
            throw new ArgumentException("Status description cannot be empty.", nameof(statusDescription));
        if (statusDescription == "OPERATIONAL")
            Status = EStatus.OPERATIONAL;
        else if (statusDescription == "UNOPERATIONAL")
            Status = EStatus.UNOPERATIONAL;
        else
        {
            throw new ArgumentException($"Status description {statusDescription} is not valid.", nameof(statusDescription));
        }

    }

   


}

