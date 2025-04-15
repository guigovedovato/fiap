using BookStore.Core.Entity;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Interface.Data.Query;

namespace BookStore.Service.Query;

public class BookQueryService : QueryService<Book>, IBookQueryService
{
    private readonly IBookQueryRepository _repository;
    public BookQueryService(IBookQueryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<Book?> GetByStockIdAsync(Guid stockId)
    {
        return _repository.GetByStockIdAsync(stockId);
    }

    public Task<IEnumerable<Book>> GetBySellerIdAsync(Guid sellerId)
    {
        return _repository.GetBySellerIdAsync(sellerId);
    }
}