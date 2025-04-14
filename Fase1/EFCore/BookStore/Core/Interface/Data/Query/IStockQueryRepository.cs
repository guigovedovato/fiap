using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Data.Query;

public interface IStockQueryRepository : IQueryRepository<Stock>
{
    Task<Stock> GetByBookIdAsync(Guid bookId);
    Task<IEnumerable<Stock>> GetBySellerIdAsync(Guid sellerId);
}