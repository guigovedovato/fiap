using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Query;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repository.Query;

public class BookQueryRepository : QueryRepository<Book>, IBookQueryRepository
{
    public BookQueryRepository(QueryDbContext context) : base(context) {}

    public async Task<IEnumerable<Book>> GetBySellerIdAsync(Guid sellerId)
    {
        return await _context.Books
                             .Include(a => a.Seller)
                             .Where(x => x.Seller.Id == sellerId)
                             .ToListAsync();
    }

    public async Task<Book?> GetByStockIdAsync(Guid stockId)
    {
        return await _context.Books
                             .Include(a => a.Stock)
                             .FirstOrDefaultAsync(x => x.Stock.Id == stockId);
    }
}