using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Query;
using BookStore.Infrastructure.Data.Context;

namespace BookStore.Infrastructure.Data.Repository.Query;

public class BookQueryRepository : QueryRepository<Book>, IBookQueryRepository
{
    public BookQueryRepository(QueryDbContext context) : base(context) {}

    public Task<IEnumerable<Book>> GetBySellerIdAsync(int sellerId)
    {
        return Task.FromResult(Enumerable.Empty<Book>());
    }

    public Task<Book> GetByStockIdAsync(int stockId)
    {
        return Task.FromResult(null as Book);
    }
}