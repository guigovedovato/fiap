using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Data.Command;

public interface IBookCommandRepository : ICommandRepository<Book>
{
}