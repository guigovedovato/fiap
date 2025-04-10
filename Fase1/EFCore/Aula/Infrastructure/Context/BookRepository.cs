using Core.Entity;
using Core.Repository;

namespace Infrastructure.Context;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context) {}
    
    public async Task AddBulkAsync(IEnumerable<Book> books)
    {
        await _context.BulkInsertAsync(books); // Z Library
        // await _context.Books.AddRangeAsync(books); // EF Core
        // await _context.SaveChangesAsync();
    }
}