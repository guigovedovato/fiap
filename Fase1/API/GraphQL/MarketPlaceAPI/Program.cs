using MarketPlaceAPI.Auth.Infrastructure;
using MarketPlaceAPI.Auth.Interface;
using MarketPlaceAPI.Auth.Service;
using MarketPlaceAPI.Infrastructure;
using MarketPlaceAPI.Product.Interface;
using MarketPlaceAPI.Product.Repository;
using MarketPlaceAPI.Product.Service;
using MarketPlaceAPI.Product.GraphQL;
using Microsoft.EntityFrameworkCore;
using HotChocolate.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

builder.Services.AddDbContext<ProductRepository>(opt => opt.UseInMemoryDatabase("ProductRepository"));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
});

builder.Services.AddGraphQLServer()
    .AddAuthorization()
    .AddQueryType<ProductQuery>()
    .AddMutationType<ProductMutation>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi(config =>
    {
        config.DocumentTitle = "MarketPlace GraphQL API";
        config.Path = "/swagger";
        config.DocumentPath = "/swagger/{documentName}/swagger.json";
        config.DocExpansion = "list";
    });
}

app.MapAuthEndpoints();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapGraphQL().RequireAuthorization();

app.Run();
