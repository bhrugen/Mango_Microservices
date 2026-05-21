using AutoMapper;
using Mango.MessageBus;
using Mango.Services.OrderAPI.Data;
using Mango.Services.OrderAPI.Models;
using Mango.Services.OrderAPI.Models.Dto;
using Mango.Services.OrderAPI.Utility;
using Mango.Services.Shared.Extensions;
using Mango.Services.Shared.Handlers;
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
    o.CreateMap<OrderHeaderDto, CartHeaderDto>()
        .ForMember(dest => dest.CartTotal, u => u.MapFrom(src => src.OrderTotal)).ReverseMap();

    o.CreateMap<CartDetailsDto, OrderDetailsDto>()
        .ForMember(dest => dest.ProductName, u => u.MapFrom(src => src.Product.Name))
        .ForMember(dest => dest.Price, u => u.MapFrom(src => src.Product.Price));

    o.CreateMap<OrderDetailsDto, CartDetailsDto>();

    o.CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
    o.CreateMap<OrderDetailsDto, OrderDetails>().ReverseMap();
});

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<BackendApiAuthenticationHttpClientHandler>();
builder.Services.AddScoped<IMessageBus, MessageBus>();
builder.Services.AddHttpClient("Product", u => u.BaseAddress =
new Uri(builder.Configuration["ServiceUrls:ProductAPI"])).AddHttpMessageHandler<BackendApiAuthenticationHttpClientHandler>();
builder.Services.AddControllers();

// Add OpenAPI with JWT Bearer authentication using shared extension
builder.Services.AddMangoOpenApi(
    title: "Mango Order API",
    description: "Order Management API for Mango Microservices"
);

// Add JWT authentication using shared extension
builder.AddJwtAuthentication();

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline using shared extension
app.UseMangoOpenApi("Mango Order API");

Stripe.StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Apply migrations using shared extension
app.ApplyMigrations<AppDbContext>();

app.Run();
