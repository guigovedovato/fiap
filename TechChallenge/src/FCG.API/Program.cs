using FCG.API.Configuration;
using FCG.API.Configuration.Jwt;
using FCG.API.Configuration.Middleware.CorrelationId;
using FCG.API.Configuration.Middleware.GlobalExceptionHandling;
using FCG.API.Configuration.Middleware.RequestLogging;
using FCG.API.Configuration.Swagger;
using FCG.API.Service.Cache;
using MessagePack;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCorrelationIdGenerator();
builder.Services.AddBaseLogging();

builder.Services.AddMemoryCache();
builder.Services.AddCacheService();

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("Admin", policy => policy.RequireRole("Admin"))
    .AddPolicy("User", policy => policy.RequireRole("User"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.MapGet("/product", (ICacheService _cacheService) =>
{
    var key = "productList";

    if (_cacheService.Get(key) is List<string> cachedProduct)
    {
        return TypedResults.Ok(MessagePackSerializer.SerializeToJson(cachedProduct));
    }

    var productList = new List<string> { "Product 1", "Product 2" };

    _cacheService.Set(key, productList);

    return TypedResults.Ok(MessagePackSerializer.SerializeToJson(productList));
})
.WithName("Product")
.WithOpenApi();

app.UseGlobalExceptionHandling();
app.UseCorrelationMiddleware();
app.UseRequestLogging();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
