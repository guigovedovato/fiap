using BookStore.Core.Dto;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Data.Command;
using BookStore.Core.Extensions;

namespace BookStore.Service.Command;

public class AddressCommandService : IAddressCommandService 
{
    private readonly IAddressCommandRepository _repository;


    public AddressCommandService(IAddressCommandRepository repository)
    {
        _repository = repository;
    }    

    public async Task AddAsync(AddressDto addressDto)
    {
        await _repository.AddAsync(addressDto.ToEntity());
    }

    public async Task UpdateAsync(AddressDto addressDto)
    {
        await _repository.UpdateAsync(addressDto.ToEntity());
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}