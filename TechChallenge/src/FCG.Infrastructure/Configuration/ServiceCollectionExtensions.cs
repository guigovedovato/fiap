using FCG.Infrastructure.Cache;
using FCG.Infrastructure.CorrelationId;
using FCG.Infrastructure.Log;
using FCG.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace FCG.Infrastructure.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ICorrelationIdGenerator, CorrelationIdGenerator>();
        services.AddTransient(typeof(BaseLogger));
        services.AddTransient<ICacheService, MemCacheService>();
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();

        return services;
    }
}