using Core.Entity;

namespace Core.Repository;

public interface IBookRepository : IRepository<Book>
{
    Task AddBulkAsync(IEnumerable<Book> books);
}
