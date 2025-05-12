using FCG.Infrastructure.Cache;
using FCG.Infrastructure.CorrelationId;
using FCG.Infrastructure.Log;
using FCG.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FCG.Infrastructure.Data.Context;
using FCG.Infrastructure.Data.Repository;

namespace FCG.Infrastructure.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ICorrelationIdGenerator, CorrelationIdGenerator>();
        services.AddTransient(typeof(BaseLogger));
        services.AddTransient<ICacheService, MemCacheService>();
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddRepository();
        services.AddSqlContext(services.BuildServiceProvider().GetRequiredService<IConfiguration>());

        return services;
    }

    private static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ILoginRepository, LoginRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<ILibraryRepository, LibraryRepository>();
    }

    private static void AddSqlContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            options.UseLazyLoadingProxies();
        }, ServiceLifetime.Scoped);
    }
}