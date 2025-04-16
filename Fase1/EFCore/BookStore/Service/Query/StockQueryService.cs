using BookStore.Core.Dto;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Interface.Data.Query;
using BookStore.Core.Extensions;

namespace BookStore.Service.Query;

public class StockQueryService : IStockQueryService
{
    private readonly IStockQueryRepository _repository;

    public StockQueryService(IStockQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<StockDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        if (entities == null) return Enumerable.Empty<StockDto>();
        return entities.Select(e => e.ToDto());
    }

    public async Task<StockDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;
        return entity.ToDto();
    }

    public async Task<StockDto?> GetByBookIdAsync(Guid bookId)
    {
        var entity = await _repository.GetByBookIdAsync(bookId);
        if (entity == null) return null;
        return entity.ToDto();
    }

    public async Task<IEnumerable<StockDto>> GetBySellerIdAsync(Guid sellerId)
    {
        var entities = await _repository.GetBySellerIdAsync(sellerId);
        if (entities == null) return Enumerable.Empty<StockDto>();
        return entities.Select(e => e.ToDto());
    }
}