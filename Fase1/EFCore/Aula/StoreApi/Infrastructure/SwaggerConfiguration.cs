using NSwag;
using NSwag.Generation.Processors.Security;

namespace StoreApi.Infrastructure;

public static class SwaggerConfiguration
{
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddOpenApiDocument(options =>
        {
            options.DocumentName = "Store Minimal API";
            options.Title = "Store Minimal API v1";
            options.Version = "v1";
        });
    }
}