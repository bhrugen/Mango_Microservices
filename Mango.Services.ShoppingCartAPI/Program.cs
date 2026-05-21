using AutoMapper;
using Mango.MessageBus;
using Mango.Services.Shared.Extensions;
using Mango.Services.Shared.Handlers;
using Mango.Services.ShoppingCartAPI.Data;
using Mango.Services.ShoppingCartAPI.Models;
using Mango.Services.ShoppingCartAPI.Models.Dto;
using Mango.Services.ShoppingCartAPI.Service;
using Mango.Services.ShoppingCartAPI.Service.IService;
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
    o.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
    o.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<BackendApiAuthenticationHttpClientHandler>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IMessageBus, MessageBus>();
builder.Services.AddHttpClient("Product", u => u.BaseAddress =
new Uri(builder.Configuration["ServiceUrls:ProductAPI"])).AddHttpMessageHandler<BackendApiAuthenticationHttpClientHandler>();
builder.Services.AddHttpClient("Coupon", u => u.BaseAddress =
new Uri(builder.Configuration["ServiceUrls:CouponAPI"])).AddHttpMessageHandler<BackendApiAuthenticationHttpClientHandler>();
builder.Services.AddControllers();

// Add OpenAPI with JWT Bearer authentication using shared extension
builder.Services.AddMangoOpenApi(
    title: "Mango Shopping Cart API",
    description: "Shopping Cart Management API for Mango Microservices"
);

// Add JWT authentication using shared extension
builder.AddJwtAuthentication();

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline using shared extension
app.UseMangoOpenApi("Mango Shopping Cart API");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Apply migrations using shared extension
app.ApplyMigrations<AppDbContext>();

app.Run();
