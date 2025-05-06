namespace FCG.API.Configuration.Middleware.CorrelationId;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCorrelationIdGenerator(this IServiceCollection services)
    {
        services.AddTransient<ICorrelationIdGenerator, CorrelationIdGenerator>();

        return services;
    }
}