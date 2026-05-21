using AutoMapper;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto;
using Mango.Services.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddAutoMapper(o =>
{
    o.CreateMap<CouponDto, Coupon>();
    o.CreateMap<Coupon, CouponDto>();
});




builder.Services.AddControllers();

// Add health checks using shared extension
builder.Services.AddMangoHealthChecks<AppDbContext>("CouponAPI");

// Add OpenAPI with JWT Bearer authentication using shared extension
builder.Services.AddMangoOpenApi(
    title: "Mango Coupon API",
    description: "Coupon Management API for Mango Microservices"
);

// Add JWT authentication using shared extension
builder.AddJwtAuthentication();

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure health check endpoints using shared extension
app.UseMangoHealthChecks();

// Configure the HTTP request pipeline using shared extension
app.UseMangoOpenApi("Mango Coupon API");

Stripe.StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Apply migrations using shared extension
app.ApplyMigrations<AppDbContext>();

app.Run();
