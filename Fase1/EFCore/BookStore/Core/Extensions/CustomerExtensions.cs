using BookStore.Core.Entity;
using BookStore.Core.Dto;
using BookStore.Core.Vm;

namespace BookStore.Core.Extensions;

public static class CustomerExtensions
{
    public static CustomerDto ToDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id,
            CreatedAt = customer.CreatedAt,
            UpdatedAt = customer.UpdatedAt,
            Name = customer.Name,
            Email = customer.Email,
            Phone = customer.Phone,
            AddressId = customer.AddressId
        };
    }

    public static CustomerDto ToDto(this CustomerVm customerVm)
    {
        return new CustomerDto
        {
            Name = customerVm.Name,
            Email = customerVm.Email,
            Phone = customerVm.Phone,
            AddressId = customerVm.AddressId
        };
    }

    public static Customer ToEntity(this CustomerDto customer)
    {
        return new Customer
        {
            Name = customer.Name,
            Email = customer.Email,
            Phone = customer.Phone,
            AddressId = customer.AddressId
        };
    }

    public static CustomerVm ToVm(this CustomerDto customer)
    {
        return new CustomerVm
        {
            Id = customer.Id,
            CreatedAt = customer.CreatedAt,
            UpdatedAt = customer.UpdatedAt,
            Name = customer.Name,
            Email = customer.Email,
            Phone = customer.Phone,
            AddressId = customer.AddressId
        };
    }
}
