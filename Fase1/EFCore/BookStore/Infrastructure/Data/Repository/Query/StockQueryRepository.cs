using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Query;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repository.Query;

public class StockQueryRepository : QueryRepository<Stock>, IStockQueryRepository
{
    public StockQueryRepository(QueryDbContext context) : base(context) {}

    public async Task<Stock?> GetByBookIdAsync(Guid bookId)
    {
        return await _context.Stocks.FirstOrDefaultAsync(x => x.BookId == bookId);
    }

    public async Task<IEnumerable<Stock>> GetBySellerIdAsync(Guid sellerId)
    {
        return await _context.Stocks.Where(x => x.SellerId == sellerId).ToListAsync();
    }
}