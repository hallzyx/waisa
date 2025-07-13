using isa.Maintenance.Domain.Model.Commands;
using isa.Maintenance.Domain.Model.ValueObjects;

namespace isa.Maintenance.Domain.Model.Aggregates;

public class MaintenanceActivity
{
    public int Id { get; set; }
    public string ProductSerialNumber { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public EActivityResult ActivityResult { get; set; }

    public MaintenanceActivity(){}

    public MaintenanceActivity(CreateMaintenanceActivityCommand command)
    {
        if(command.ProductSerialNumber == null)
            throw new ArgumentNullException(nameof(command.ProductSerialNumber), "Product serial number cannot be null.");
        if(command.Summary == null)
            throw new ArgumentNullException(nameof(command.Summary), "Summary cannot be null.");
        if(command.Description == null)
            throw new ArgumentNullException(nameof(command.Description), "Description cannot be null.");
        if (command.ProductSerialNumber.Length == 0)
            throw new ArgumentException("Product serial number cannot be empty.", nameof(command.ProductSerialNumber));
        if (command.Summary.Length == 0)
            throw new ArgumentException("Summary cannot be empty.", nameof(command.Summary));
        if (command.Description.Length == 0)
            throw new ArgumentException("Description cannot be empty.", nameof(command.Description));
        if (!Enum.TryParse<EActivityResult>(command.ActivityResult, true, out _))
        {
            throw new ArgumentException("Invalid activity result value.", nameof(command.ActivityResult));
        }
        ProductSerialNumber = command.ProductSerialNumber;
        Summary = command.Summary;
        Description = command.Description;
        ActivityResult = (EActivityResult)Enum.Parse(typeof(EActivityResult), command.ActivityResult, true);
    }
    
    
}