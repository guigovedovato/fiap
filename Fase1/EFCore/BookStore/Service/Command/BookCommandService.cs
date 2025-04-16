using BookStore.Core.Dto;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Data.Command;
using BookStore.Core.Extensions;

namespace BookStore.Service.Command;

public class BookCommandService : IBookCommandService
{
    private readonly IBookCommandRepository _repository;

    public BookCommandService(IBookCommandRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(BookDto bookDto)
    {
        await _repository.AddAsync(bookDto.ToEntity());
    }

    public async Task UpdateAsync(BookDto bookDto)
    {
        await _repository.UpdateAsync(bookDto.ToEntity());
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}