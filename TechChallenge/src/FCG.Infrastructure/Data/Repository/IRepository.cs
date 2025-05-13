using FCG.Domain.Common;

namespace FCG.Infrastructure.Data.Repository;

public interface IRepository<T> where T : EntityBase
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T?> UpdateAsync(Guid id, T entity);
    Task<bool> DeleteAsync(Guid id);
}
