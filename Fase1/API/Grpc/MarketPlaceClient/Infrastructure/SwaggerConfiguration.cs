using NSwag;
using NSwag.Generation.Processors.Security;

namespace MarketPlaceClient.Infrastructure;

public static class SwaggerConfiguration
{
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddOpenApiDocument(options =>
        {
            options.DocumentName = "MarketPlaceClient gRPC API";
            options.Title = "MarketPlaceClient gRPC API v1";
            options.Version = "v1";
        });
    }
}