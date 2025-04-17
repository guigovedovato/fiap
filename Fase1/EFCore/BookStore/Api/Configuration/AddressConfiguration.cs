using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Vm;
using BookStore.Core.Dto;
using BookStore.Core.Extensions;

namespace BookStore.Api.Configuration;

public static class AddressConfiguration
{
    public static void MapAddressEndpoints(this WebApplication app)
    {
        var addressGroup = app.MapGroup("/addresses");

        addressGroup.MapGet("/", GetAllAddresses);
        addressGroup.MapGet("/{id}", GetAddressById);
        addressGroup.MapPost("/", CreateAddress);
        addressGroup.MapPut("/", UpdateAddress);
        addressGroup.MapDelete("/{id}", DeleteAddress);

        addressGroup.MapGet("/customer/{id}", GetByCustomerIdAsync);
        addressGroup.MapGet("/seller/{id}", GetBySellerIdAsync);
    }

    private static async Task<IResult> GetAllAddresses(IAddressQueryService addressService)
    {
        var addresses = await addressService.GetAllAsync();
        return Results.Ok(addresses);
    }

    private static async Task<IResult> GetAddressById(IAddressQueryService addressService, Guid id)
    {
        var address = await addressService.GetByIdAsync(id);
        return address is not null ? Results.Ok(address) : Results.NotFound();
    }

    private static async Task<IResult> CreateAddress(IAddressCommandService addressService, AddressVm address)
    {
        await addressService.AddAsync(address.ToDto());
        return Results.Created($"/addresses/{address.Id}", address);
    }

    private static async Task<IResult> UpdateAddress(IAddressCommandService addressService, IAddressQueryService addressQueryService, AddressVm address)
    {
        var existingAddress = await addressQueryService.GetByIdAsync(address.Id);
        if (existingAddress is null) return Results.NotFound();

        await addressService.UpdateAsync(address.ToDto());
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteAddress(IAddressCommandService addressService, IAddressQueryService addressQueryService, Guid id)
    {
        var existingAddress = await addressQueryService.GetByIdAsync(id);
        if (existingAddress is null) return Results.NotFound();

        await addressService.DeleteAsync(id);
        return Results.NoContent();
    }

    private static async Task<IResult> GetByCustomerIdAsync(IAddressQueryService addressService, Guid id)
    {
        var address = await addressService.GetByCustomerIdAsync(id);
        return address is not null ? Results.Ok(address) : Results.NotFound();
    }

    private static async Task<IResult> GetBySellerIdAsync(IAddressQueryService addressService, Guid id)
    {
        var address = await addressService.GetBySellerIdAsync(id);
        return address is not null ? Results.Ok(address) : Results.NotFound();
    }
}