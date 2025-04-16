using BookStore.Core.Dto;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Interface.Data.Query;
using BookStore.Core.Extensions;

namespace BookStore.Service.Query;

public class BookQueryService : IBookQueryService
{
    private readonly IBookQueryRepository _repository;
    
    public BookQueryService(IBookQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<BookDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        if (entities == null) return Enumerable.Empty<BookDto>();
        return entities.Select(entity => entity.ToDto());
    }

    public async Task<BookDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity == null) return null;
        return entity.ToDto();
    }

    public async Task<BookDto?> GetByStockIdAsync(Guid stockId)
    {
         var entity = await _repository.GetByStockIdAsync(stockId);
         if (entity == null) return null;
         return entity.ToDto();
    }

    public async Task<IEnumerable<BookDto>> GetBySellerIdAsync(Guid sellerId)
    {
         var entities = await _repository.GetBySellerIdAsync(sellerId);
         if (entities == null) return Enumerable.Empty<BookDto>();
         return entities.Select(entity => entity.ToDto());
    }
}