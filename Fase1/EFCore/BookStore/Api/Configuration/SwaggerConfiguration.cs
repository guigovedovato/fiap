using NSwag;

namespace BookStore.Api.Configuration;

public static class SwaggerConfiguration
{
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddOpenApiDocument(options =>
        {
            options.DocumentName = "Book Store API";
            options.Title = "Book Store API v1";
            options.Version = "v1";
        });
    }

    public static void UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseOpenApi();
        app.UseSwaggerUi(config =>
        {
            config.DocumentTitle = "Book Store API";
            config.Path = "/swagger";
            config.DocumentPath = "/swagger/{documentName}/swagger.json";
            config.DocExpansion = "list";
        });
    }
}
