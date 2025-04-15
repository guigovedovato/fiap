using BookStore.Core.Entity;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Interface.Data.Query;

namespace BookStore.Service.Query;

public class StockQueryService : QueryService<Stock>, IStockQueryService
{
    private readonly IStockQueryRepository _repository;

    public StockQueryService(IStockQueryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public async Task<Stock?> GetByBookIdAsync(Guid bookId)
    {
        return await _repository.GetByBookIdAsync(bookId);
    }

    public async Task<IEnumerable<Stock>> GetBySellerIdAsync(Guid sellerId)
    {
        return await _repository.GetBySellerIdAsync(sellerId);
    }
}