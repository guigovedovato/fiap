using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Service.Query;

public interface IStockQueryService : IQueryService<Stock>
{
    Task<Stock?> GetByBookIdAsync(Guid bookId);
    Task<IEnumerable<Stock>> GetBySellerIdAsync(Guid sellerId);
}