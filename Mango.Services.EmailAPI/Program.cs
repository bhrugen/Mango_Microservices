using Mango.Services.EmailAPI.Data;
using Mango.Services.EmailAPI.Extension;
using Mango.Services.EmailAPI.Messaging;
using Mango.Services.EmailAPI.Services;
using Mango.Services.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


var optionBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton(new EmailService(optionBuilder.Options));


builder.Services.AddSingleton<IAzureServiceBusConsumer, AzureServiceBusConsumer>();
builder.Services.AddControllers();

// Add OpenAPI using shared extension (no auth required for background service)
builder.Services.AddMangoOpenApi(
    title: "Mango Email API",
    description: "Email Service API for Mango Microservices",
    requiresAuth: false
);

var app = builder.Build();

// Configure the HTTP request pipeline using shared extension
app.UseMangoOpenApi("Mango Email API");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Apply migrations using shared extension
app.ApplyMigrations<AppDbContext>();

app.UseAzureServiceBusConsumer();
app.Run();
