using BookStore.Core.Dto;

namespace BookStore.Core.Interface.Service.Command;

public interface ICustomerCommandService
{
    Task AddAsync(CustomerDto customerDto);
    Task UpdateAsync(CustomerDto customerDto);
    Task DeleteAsync(Guid id);
}