using AutoMapper;
using Mango.Services.ProductAPI.Data;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configure AutoMapper
builder.Services.AddAutoMapper(o =>
{
    o.CreateMap<ProductDto, Product>().ReverseMap();
});

builder.Services.AddControllers();

// Add health checks using shared extension
builder.Services.AddMangoHealthChecks<AppDbContext>("ProductAPI");

// Add OpenAPI with JWT Bearer authentication using shared extension
builder.Services.AddMangoOpenApi(
    title: "Mango Product API",
    description: "Product Management API for Mango Microservices"
);

// Add JWT authentication using shared extension
builder.AddJwtAuthentication();

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure health check endpoints using shared extension
app.UseMangoHealthChecks();

// Configure the HTTP request pipeline using shared extension
app.UseMangoOpenApi("Mango Product API");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

// Apply migrations using shared extension
app.ApplyMigrations<AppDbContext>();

app.Run();
