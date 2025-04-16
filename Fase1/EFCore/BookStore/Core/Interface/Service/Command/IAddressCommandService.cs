using BookStore.Core.Dto;

namespace BookStore.Core.Interface.Service.Command;

public interface IAddressCommandService
{
    Task AddAsync(AddressDto addressDto);
    Task UpdateAsync(AddressDto addressDto);
    Task DeleteAsync(Guid id);
}