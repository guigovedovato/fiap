using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Stocks API",
        Version = "v1",
        Description = "Descrição da Sua API",
        Contact = new OpenApiContact
        {
            Name = "Thiago S Adriano",
            Email = "prof.thiagoadriano@teste.com",
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () =>
{
    TypedResults.Ok("Products");
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();
