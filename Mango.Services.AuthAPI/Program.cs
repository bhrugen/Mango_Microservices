using Mango.MessageBus;
using Mango.Services.AuthAPI.Data;
using Mango.Services.AuthAPI.Models;
using Mango.Services.AuthAPI.Service;
using Mango.Services.AuthAPI.Service.IService;
using Mango.Services.Shared.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddControllers();

// Add health checks using shared extension
builder.Services.AddMangoHealthChecks<AppDbContext>("AuthAPI");

builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMessageBus, MessageBus>();

// Add OpenAPI using shared extension (no auth required for Auth API itself)
builder.Services.AddMangoOpenApi(
    title: "Mango Auth API",
    description: "Authentication and Authorization API for Mango Microservices",
    requiresAuth: false
);

var app = builder.Build();

// Configure health check endpoints using shared extension
app.UseMangoHealthChecks();

// Configure the HTTP request pipeline using shared extension
app.UseMangoOpenApi("Mango Auth API");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Apply migrations using shared extension
app.ApplyMigrations<AppDbContext>();

app.Run();
