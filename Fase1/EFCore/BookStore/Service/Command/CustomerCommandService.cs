using BookStore.Core.Dto;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Data.Command;
using BookStore.Core.Extensions;

namespace BookStore.Service.Command;

public class CustomerCommandService : ICustomerCommandService
{
    private readonly ICustomerCommandRepository _repository;

    public CustomerCommandService(ICustomerCommandRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(CustomerDto customerDto)
    {
        await _repository.AddAsync(customerDto.ToEntity());
    }

    public async Task UpdateAsync(CustomerDto customerDto)
    {
        await _repository.UpdateAsync(customerDto.ToEntity());
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}