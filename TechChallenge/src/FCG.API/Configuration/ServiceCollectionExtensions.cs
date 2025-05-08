using FCG.API.Service.Cache;
using FCG.API.Service.CorrelationId;
using FCG.API.Service.Log;

namespace FCG.API.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCorrelationIdGenerator(this IServiceCollection services)
    {
        services.AddTransient<ICorrelationIdGenerator, CorrelationIdGenerator>();

        return services;
    }

    public static IServiceCollection AddBaseLogging(this IServiceCollection services)
    {
        services.AddTransient(typeof(BaseLogger));

        return services;
    }

    public static IServiceCollection AddCacheService(this IServiceCollection services)
    {
        services.AddScoped<ICacheService, MemCacheService>();

        return services;
    }
}