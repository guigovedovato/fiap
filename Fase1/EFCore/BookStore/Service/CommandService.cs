using BookStore.Core.Entity;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Data;

namespace BookStore.Service;

public class CommandService<T> : ICommandService<T> where T : EntityBase
{
    private readonly ICommandRepository<T> _commandRepository;

    public CommandService(ICommandRepository<T> commandRepository)
    {
        _commandRepository = commandRepository;
    }

    public async Task AddAsync(T entity)
    {
        await _commandRepository.AddAsync(entity);
    }

    public async Task UpdateAsync(T entity)
    {
        await _commandRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _commandRepository.DeleteAsync(id);
    }
}
