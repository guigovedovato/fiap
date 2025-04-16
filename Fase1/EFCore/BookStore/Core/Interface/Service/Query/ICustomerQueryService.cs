using BookStore.Core.Dto;

namespace BookStore.Core.Interface.Service.Query;

public interface ICustomerQueryService
{
    Task<IEnumerable<CustomerDto>> GetAllAsync();
    Task<CustomerDto?> GetByIdAsync(Guid id);
}