using BookStore.Core.Dto;

namespace BookStore.Core.Interface.Service.Command;

public interface IBookCommandService
{
    Task AddAsync(BookDto bookDto);
    Task UpdateAsync(BookDto bookDto);
    Task DeleteAsync(Guid id);
}