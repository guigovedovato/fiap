using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Data;

public interface ICommandRepository<T> where T : EntityBase
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
}
