using Mango.Services.RewardAPI.Data;
using Mango.Services.RewardAPI.Extension;
using Mango.Services.RewardAPI.Messaging;
using Mango.Services.RewardAPI.Services;
using Mango.Services.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton(new RewardService(optionBuilder.Options));

builder.Services.AddSingleton<IAzureServiceBusConsumer, AzureServiceBusConsumer>();

builder.Services.AddControllers();

// Add health checks using shared extension
builder.Services.AddMangoHealthChecks<AppDbContext>("RewardAPI");

// Add OpenAPI using shared extension (no auth required for background service)
builder.Services.AddMangoOpenApi(
    title: "Mango Reward API",
    description: "Reward Service API for Mango Microservices",
    requiresAuth: false
);

var app = builder.Build();

// Configure health check endpoints using shared extension
app.UseMangoHealthChecks();

// Configure the HTTP request pipeline using shared extension
app.UseMangoOpenApi("Mango Reward API");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Apply migrations using shared extension
app.ApplyMigrations<AppDbContext>();

app.UseAzureServiceBusConsumer();
app.Run();
