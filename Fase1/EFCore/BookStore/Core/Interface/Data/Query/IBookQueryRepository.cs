using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Data.Query;

public interface IBookQueryRepository : IQueryRepository<Book>
{
    Task<IEnumerable<Book>> GetBySellerIdAsync(Guid sellerId);
    Task<Book?> GetByStockIdAsync(Guid stockId);
}