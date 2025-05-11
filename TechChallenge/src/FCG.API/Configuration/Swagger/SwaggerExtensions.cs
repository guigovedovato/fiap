using Microsoft.OpenApi.Models;

namespace FCG.API.Configuration.Swagger;

public static class SwaggerExtensions
{
    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "FIAP Cloud Game API",
                Version = "v1",
                Description = "A FIAP Cloud Games (FCG) é uma plataforma de venda de jogos digitais e gestão de servidores para partidas online."
            });

            c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Description = "Please, insert 'Bearer' [space] and the token JWT",
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });
    }
}