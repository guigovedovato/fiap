using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Service;

public interface ICommandService<T> where T : EntityBase
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}
