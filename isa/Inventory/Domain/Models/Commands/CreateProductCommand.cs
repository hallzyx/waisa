

namespace isa.Inventory.Domain.Models.Commands;

public record CreateProductCommand(string Brand,
                                   string Model,
                                   string SerialNumber,
                                   string StatusDescription);

