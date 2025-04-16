using BookStore.Core.Dto;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Interface.Data.Query;
using BookStore.Core.Extensions;

namespace BookStore.Service.Query;

public class CustomerQueryService : ICustomerQueryService
{
    private readonly ICustomerQueryRepository _repository;

    public CustomerQueryService(ICustomerQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        if (entities == null) return Enumerable.Empty<CustomerDto>();
        return entities.Select(e => e.ToDto());
    }

    public async Task<CustomerDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;
        return entity.ToDto();
    }
}