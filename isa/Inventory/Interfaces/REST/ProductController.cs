using System.Net.Mime;
using isa.Inventory.Domain.Models.Queries;
using isa.Inventory.Domain.Services;
using isa.Inventory.Interfaces.REST.Resources;
using isa.Inventory.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace isa.Inventory.Interfaces.REST;
[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Product management operations")]
public class ProductController(IProductCommandService productCommandService, IProductQueryService productQueryService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create a new Product")]
    [SwaggerResponse(201, type: typeof(ProductResource))]
    [SwaggerResponse(400, "Invalid input data")]
    public async Task<ActionResult> CreateProduct([FromBody] CreateProductResource resource)
    {
        try
        {

            var command = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
            var newProduct = await productCommandService.Handle(command);
            if(newProduct == null) return BadRequest("Product creation failed.");
            var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(newProduct);
            return Created(string.Empty, productResource);

        }catch( Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get a Product by Serial Number")]
    [SwaggerResponse(200, type: typeof(ProductResource))]
    [SwaggerResponse(404, "Product not found")]
    public async Task<ActionResult> GetProductById([FromRoute] int id)
    {
        try
        {
            var query = new GetProductByIdQuery(id);
            var certainProduct = await productQueryService.Handle(query);
            if (certainProduct == null)
            {
                return NotFound($"Product with ID {id} not found.");
            }

            return Ok(ProductResourceFromEntityAssembler.ToResourceFromEntity(certainProduct));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}