using BookStore.Core.Dto;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Interface.Data.Query;
using BookStore.Core.Extensions;

namespace BookStore.Service.Query;

public class SellerQueryService : ISellerQueryService
{
    private readonly ISellerQueryRepository _repository;

    public SellerQueryService(ISellerQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<SellerDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        if (entities == null) return Enumerable.Empty<SellerDto>();
        return entities.Select(e => e.ToDto());
    }

    public async Task<SellerDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;
        return entity.ToDto();
    }
}