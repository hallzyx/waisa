namespace isa.Inventory.Interfaces.REST.Resources;

public record CreateProductResource(string Brand, string Model, string SerialNumber, string StatusDescription);
