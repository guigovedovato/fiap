using FCG.API.Service.Cache;
using FCG.API.Service.CorrelationId;
using FCG.API.Service.Log;
using FCG.Application.Authentication;
using FCG.Application.Profile;
using FCG.Application.Store;
using FCG.Domain.Authentication;
using FCG.Domain.Profile;
using FCG.Domain.Store;

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

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGameService, GameService>();
        services.AddScoped<ILoginService, LoginService>();

        return services;
    }
}