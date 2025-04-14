using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Service;

public interface IQueryService<T> where T : EntityBase
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
}
