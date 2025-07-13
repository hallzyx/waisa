using System.Net.Mime;
using isa.Maintenance.Domain.Repositories;
using isa.Maintenance.Domain.Services;
using isa.Maintenance.Interfaces.REST.Resources;
using isa.Maintenance.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace isa.Maintenance.Interfaces;

[ApiController]
[Route("api/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Maintenance activity management operations")]
public class MaintenanceActivityController(IMaintenanceActivityCommandService maintenanceActivityCommandService) : ControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create a new maintenance activity")]
    [SwaggerResponse(201, type: typeof(MaintenanceActivityResource))]
    [SwaggerResponse(400, "Invalid input data")]
    public async Task<ActionResult> CreateMaintenanceActivity([FromBody] CreateMaintenanceActivityResource resource)
    {
        try
        {
            var command = CreateMaintenanceActivityCommandFromResourceAssembler.ToCommandFromResource(resource);
            var newActivity = await maintenanceActivityCommandService.Handle(command);
            if (newActivity == null) return BadRequest("Maintenance activity creation failed.");
            var activityResource = MaintenanceActivityResourceFromEntityAssembler.ToResourceFromEntity(newActivity);
            return Created(string.Empty, activityResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}