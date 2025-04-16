using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Vm;
using BookStore.Core.Dto;
using BookStore.Core.Extensions;

namespace BookStore.Api.Configuration;

public static class SellerConfiguration
{
    public static void MapSellerEndpoints(this WebApplication app)
    {
        var sellerGroup = app.MapGroup("/sellers");

        sellerGroup.MapGet("/", GetAllSellers);
        sellerGroup.MapGet("/{id}", GetSellerById);
        sellerGroup.MapPost("/", CreateSeller);
        sellerGroup.MapPut("/", UpdateSeller);
        sellerGroup.MapDelete("/{id}", DeleteSeller);
    }

    private static async Task<IResult> GetAllSellers(ISellerQueryService sellerService)
    {
        var sellers = await sellerService.GetAllAsync();
        return Results.Ok(sellers);
    }

    private static async Task<IResult> GetSellerById(ISellerQueryService sellerService, Guid id)
    {
        var seller = await sellerService.GetByIdAsync(id);
        return seller is not null ? Results.Ok(seller) : Results.NotFound();
    }

    private static async Task<IResult> CreateSeller(ISellerCommandService sellerService, SellerVm seller)
    {
        await sellerService.AddAsync(seller.ToDto());
        return Results.Created($"/sellers/{seller.Id}", seller);
    }

    private static async Task<IResult> UpdateSeller(ISellerCommandService sellerService, ISellerQueryService sellerQueryService, SellerVm seller)
    {
        var existingSeller = await sellerQueryService.GetByIdAsync(seller.Id);
        if (existingSeller is null) return Results.NotFound();

        await sellerService.UpdateAsync(seller.ToDto());
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteSeller(ISellerCommandService sellerService, ISellerQueryService sellerQueryService, Guid id)
    {
        var existingSeller = await sellerQueryService.GetByIdAsync(id);
        if (existingSeller is null) return Results.NotFound();

        await sellerService.DeleteAsync(id);
        return Results.NoContent();
    }
}