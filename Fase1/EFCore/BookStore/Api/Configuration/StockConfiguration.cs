using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Vm;
using BookStore.Core.Dto;
using BookStore.Core.Extensions;

namespace BookStore.Api.Configuration;

public static class StockConfiguration
{
    public static void MapStockEndpoints(this WebApplication app)
    {
        var stockGroup = app.MapGroup("/stocks");

        stockGroup.MapGet("/", GetAllStocks);
        stockGroup.MapGet("/{id}", GetStockById);
        stockGroup.MapPost("/", CreateStock);
        stockGroup.MapPut("/", UpdateStock);
        stockGroup.MapDelete("/{id}", DeleteStock);
    }

    private static async Task<IResult> GetAllStocks(IStockQueryService stockService)
    {
        var stocks = await stockService.GetAllAsync();
        return Results.Ok(stocks);
    }

    private static async Task<IResult> GetStockById(IStockQueryService stockService, Guid id)
    {
        var stock = await stockService.GetByIdAsync(id);
        return stock is not null ? Results.Ok(stock) : Results.NotFound();
    }

    private static async Task<IResult> CreateStock(IStockCommandService stockService, StockVm stock)
    {
        await stockService.AddAsync(stock.ToDto());
        return Results.Created($"/stocks/{stock.Id}", stock);
    }

    private static async Task<IResult> UpdateStock(IStockCommandService stockService, IStockQueryService stockQueryService, StockVm stock)
    {
        var existingStock = await stockQueryService.GetByIdAsync(stock.Id);
        if (existingStock is null) return Results.NotFound();

        await stockService.UpdateAsync(stock.ToDto());
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteStock(IStockCommandService stockService, IStockQueryService stockQueryService, Guid id)
    {
        var existingStock = await stockQueryService.GetByIdAsync(id);
        if (existingStock is null) return Results.NotFound();

        await stockService.DeleteAsync(id);
        return Results.NoContent();
    }
}