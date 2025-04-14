using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Service.Query;

public interface IBookQueryService : IQueryService<Book>
{
    Task<IEnumerable<Book>> GetBySellerIdAsync(Guid sellerId);
    Task<Book?> GetByStockIdAsync(Guid stockId);
}