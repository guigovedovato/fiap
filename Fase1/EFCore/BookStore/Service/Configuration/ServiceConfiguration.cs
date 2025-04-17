using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Service.Query;
using BookStore.Service;
using BookStore.Service.Command;
using BookStore.Service.Query;
using BookStore.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace BookStore.Service.Configuration;

public static class ServiceConfiguration
{
    public static void AddService(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration.GetConnectionString("InMemory") == "true")
        {
            services.AddInMemoryContext(); // Register the infrastructure layer
        }
        else
        {
            services.AddSqlContext(configuration); // Register the infrastructure layer
        }

        services.AddRepository(); // Register the infrastructure layer

        services.AddScoped<IAddressCommandService, AddressCommandService>();
        services.AddScoped<IBookCommandService, BookCommandService>();
        services.AddScoped<ICustomerCommandService, CustomerCommandService>();
        services.AddScoped<ISellerCommandService, SellerCommandService>();
        services.AddScoped<IStockCommandService, StockCommandService>();

        services.AddScoped<IAddressQueryService, AddressQueryService>();
        services.AddScoped<IBookQueryService, BookQueryService>();
        services.AddScoped<ICustomerQueryService, CustomerQueryService>();
        services.AddScoped<ISellerQueryService, SellerQueryService>();
        services.AddScoped<IStockQueryService, StockQueryService>();
    }
}