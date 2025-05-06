using Microsoft.OpenApi.Models;
using FCG.API.Configuration.Middleware;
using FCG.API.Configuration.Middleware.CorrelationId;
using FCG.API.Configuration.Log;
using FCG.API.Configuration.Jwt;
using FGC.API.Configuration.Swagger;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCorrelationIdGenerator();
builder.Services.AddTransient(typeof(BaseLogger));

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () =>
{
    TypedResults.Ok("Products");
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.UseRequestLogging();
app.UseGlobalExceptionHandling();
app.UseCorrelationMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
