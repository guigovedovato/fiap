using Core.Entity;
using Core.Repository;

namespace Infrastructure.Context;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context) {}
}