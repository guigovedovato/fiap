using NSwag;
using NSwag.Generation.Processors.Security;

namespace MarketPlaceAPI.Infrastructure;

public static class SwaggerConfiguration
{
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddOpenApiDocument(options =>
        {
            options.DocumentName = "MarketPlace GraphQL API";
            options.Title = "MarketPlace GraphQL API v1";
            options.Version = "v1";
            options.DocumentProcessors.Add(
                new SecurityDefinitionAppender("JWT Token",
                new OpenApiSecurityScheme {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Description = "JWT Token",
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header
                    }
                )
            );
             options.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
        });
    }
}