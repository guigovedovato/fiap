using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Data;

public interface IQueryRepository<T> where T : EntityBase
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
}
