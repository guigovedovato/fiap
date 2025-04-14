using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Command;
using BookStore.Infrastructure.Data.Context;

namespace BookStore.Infrastructure.Data.Repository.Command;

public class BookCommandRepository : CommandRepository<Book>, IBookCommandRepository
{
    public BookCommandRepository(CommandDbContext context) : base(context) {}
}