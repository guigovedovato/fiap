using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Vm;
using BookStore.Core.Dto;
using BookStore.Core.Extensions;

namespace BookStore.Api.Configuration;

public static class CustomerConfiguration
{
    public static void MapCustomerEndpoints(this WebApplication app)
    {
        var customerGroup = app.MapGroup("/customers");

        customerGroup.MapGet("/", GetAllCustomers);
        customerGroup.MapGet("/{id}", GetCustomerById);
        customerGroup.MapPost("/", CreateCustomer);
        customerGroup.MapPut("/", UpdateCustomer);
        customerGroup.MapDelete("/{id}", DeleteCustomer);
    }

    private static async Task<IResult> GetAllCustomers(ICustomerQueryService customerService)
    {
        var customers = await customerService.GetAllAsync();
        return Results.Ok(customers);
    }

    private static async Task<IResult> GetCustomerById(ICustomerQueryService customerService, Guid id)
    {
        var customer = await customerService.GetByIdAsync(id);
        return customer is not null ? Results.Ok(customer) : Results.NotFound();
    }

    private static async Task<IResult> CreateCustomer(ICustomerCommandService customerService, CustomerVm customer)
    {
        await customerService.AddAsync(customer.ToDto());
        return Results.Created($"/customers/{customer.Id}", customer);
    }

    private static async Task<IResult> UpdateCustomer(ICustomerCommandService customerService, ICustomerQueryService customerQueryService, CustomerVm customer)
    {
        var existingCustomer = await customerQueryService.GetByIdAsync(customer.Id);
        if (existingCustomer is null) return Results.NotFound();

        await customerService.UpdateAsync(customer.ToDto());
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteCustomer(ICustomerCommandService customerService, ICustomerQueryService customerQueryService, Guid id)
    {
        var existingCustomer = await customerQueryService.GetByIdAsync(id);
        if (existingCustomer is null) return Results.NotFound();

        await customerService.DeleteAsync(id);
        return Results.NoContent();
    }
}