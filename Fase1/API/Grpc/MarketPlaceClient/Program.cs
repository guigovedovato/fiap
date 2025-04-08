using MarketPlaceClient.Infrastructure;
using MarketPlaceClient.Services;
using ProductApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

builder.Services
    .AddScoped<IProductService, ProductService>()
    .AddGrpcClient<ProductGrpc.ProductGrpcClient>((services, options) =>
    {
        options.Address = new Uri("http://localhost:5159");
    })
    .ConfigurePrimaryHttpMessageHandler(() =>
    {
        var handler = new HttpClientHandler();
        handler.ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

        return handler;
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "MarketPlaceClient gRPC API";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapProductEndpoints();

app.Run();
