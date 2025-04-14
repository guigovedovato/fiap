using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Service.Command;

public interface IBookCommandService : ICommandService<Book>
{
}