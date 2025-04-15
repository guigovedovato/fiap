using BookStore.Core.Interface.Data;
using BookStore.Core.Interface.Data.Command;
using BookStore.Core.Interface.Data.Query;
using BookStore.Infrastructure.Data.Repository;
using BookStore.Infrastructure.Data.Repository.Command;
using BookStore.Infrastructure.Data.Repository.Query;
using BookStore.Infrastructure.Data.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Configuration;

public static class InfrastructureConfiguration
{
    public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CommandDbContext>(options => 
        {
            options.UseSqlServer(configuration.GetConnectionString("CommandConnection"));
            options.UseLazyLoadingProxies();
        }, ServiceLifetime.Scoped);

        services.AddScoped<IAddressCommandRepository, AddressCommandRepository>();
        services.AddScoped<IBookCommandRepository, BookCommandRepository>();
        services.AddScoped<ICustomerCommandRepository, CustomerCommandRepository>();
        services.AddScoped<ISellerCommandRepository, SellerCommandRepository>();
        services.AddScoped<IStockCommandRepository, StockCommandRepository>();

        services.AddDbContext<QueryDbContext>(options => 
        {
            options.UseSqlServer(configuration.GetConnectionString("QueryConnection"));
            options.UseLazyLoadingProxies();
        }, ServiceLifetime.Scoped);

        services.AddScoped<IAddressQueryRepository, AddressQueryRepository>();
        services.AddScoped<IBookQueryRepository, BookQueryRepository>();
        services.AddScoped<ICustomerQueryRepository, CustomerQueryRepository>();
        services.AddScoped<ISellerQueryRepository, SellerQueryRepository>();
        services.AddScoped<IStockQueryRepository, StockQueryRepository>();
    }
}