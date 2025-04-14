using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Query;
using BookStore.Infrastructure.Data.Context;

namespace BookStore.Infrastructure.Data.Repository.Query;

public class StockQueryRepository : QueryRepository<Stock>, IStockQueryRepository
{
    public StockQueryRepository(QueryDbContext context) : base(context) {}

    public Task<Stock> GetByBookIdAsync(Guid bookId)
    {
        return Task.FromResult(null as Stock);
    }

    public Task<IEnumerable<Stock>> GetBySellerIdAsync(Guid sellerId)
    {
        return Task.FromResult(Enumerable.Empty<Stock>());
    }
}