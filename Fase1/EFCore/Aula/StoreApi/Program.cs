using Infrastructure.Context;
using StoreApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Core.Repository;
using StoreApi.Books;
using StoreApi.Clients;
using StoreApi.Orders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

builder.Services.AddDbContext<ApplicationDbContext>(options => 
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    options.UseLazyLoadingProxies();
}, ServiceLifetime.Scoped);

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "Store Minimal API";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapBookEndpoints();
app.MapClientEndpoints();
app.MapOrderEndpoints();

app.Run();
