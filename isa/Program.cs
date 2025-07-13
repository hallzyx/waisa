
using isa.Inventory.Application.ACL;
using isa.Inventory.Application.Commands;
using isa.Inventory.Application.Queries;
using isa.Inventory.Domain.Repositories;
using isa.Inventory.Domain.Services;
using isa.Inventory.Infrastructure.Persistance.EFC.Repositories;
using isa.Inventory.Interfaces.ACL;
using isa.Maintenance.Application.Commands;
using isa.Maintenance.Application.OutBoundServices.ACL;
using isa.Maintenance.Domain.Repositories;
using isa.Maintenance.Domain.Services;
using isa.Maintenance.Infrastructure.Persistance.EFC.Repositories;
using isa.Maintenance.Interfaces.ACL;
using isa.Shared.Infrastructure.Persistence.EFC.Configuration;
using isa.Shared.Domain.Repositories;
using isa.Shared.Infrastructure.Interfaces.ASP.Configuration;
using isa.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configure Lower Case URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Kebab Case Route Naming Convention
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.EnableAnnotations());

// Add Database Connection
// Add Database Connection

// Configure Database Context and Logging Levels
if (builder.Environment.IsDevelopment())
    builder.Services.AddDbContext<AppDbContext>(
        options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            // Verify Database Connection String
            if (connectionString is null)
                // Stop the application if the connection string is not set.
                throw new Exception("Database connection string is not set.");
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        });
else if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        var connectionStringTemplate = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionStringTemplate)) 
            // Stop the application if the connection string template is not set.
            throw new Exception("Database connection string template is not set in the configuration.");
        var connectionString = Environment.ExpandEnvironmentVariables(connectionStringTemplate);
        if (string.IsNullOrEmpty(connectionString))
            // Stop the application if the connection string is not set.
            throw new Exception("Database connection string is not set in the configuration.");
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error)
            .EnableDetailedErrors();
    });

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

/*builder.Services.AddScoped<IPreSetRepository,PreSetRepository>();
builder.Services.AddScoped<IPreSetCommandService, PreSetCommandService>();*/

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

//builder.Services.AddScoped<IProductContextFacade, ProductContextFacade>();
builder.Services.AddScoped<IInventoryContextFacade, InventoryContextFacade>();
builder.Services.AddScoped<IExternalInventoryService, ExternalInventoryService>();

builder.Services.AddScoped<IMaintenanceActivityRepository, MaintenanceActivityRepository>();
builder.Services.AddScoped<IMaintenanceActivityCommandService, MaintenanceActivityCommandService>();
var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();