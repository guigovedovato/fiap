using BookStore.Core.Entity;
using BookStore.Core.Dto;
using BookStore.Core.Vm;

namespace BookStore.Core.Extensions;

public static class AddressExtensions
{
    public static AddressDto ToDto(this Address address)
    {
        return new AddressDto
        {
            Id = address.Id,
            CreatedAt = address.CreatedAt,
            UpdatedAt = address.UpdatedAt,
            Street = address.Street,
            City = address.City,
            State = address.State,
            ZipCode = address.ZipCode,
            Country = address.Country,
        };
    }

    public static AddressDto ToDto(this AddressVm addressVm)
    {
        return new AddressDto
        {
            Street = addressVm.Street,
            City = addressVm.City,
            State = addressVm.State,
            ZipCode = addressVm.ZipCode,
            Country = addressVm.Country
        };
    }

    public static Address ToEntity(this AddressDto address)
    {
        return new Address
        {
            Street = address.Street,
            City = address.City,
            State = address.State,
            ZipCode = address.ZipCode,
            Country = address.Country
        };
    }

    public static AddressVm ToVm(this AddressDto address)
    {
        return new AddressVm
        {
            Id = address.Id,
            CreatedAt = address.CreatedAt,
            UpdatedAt = address.UpdatedAt,
            Street = address.Street,
            City = address.City,
            State = address.State,
            ZipCode = address.ZipCode,
            Country = address.Country
        };
    }
}