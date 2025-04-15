using BookStore.Core.Entity;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Data;

namespace BookStore.Service;

public class QueryService<T> : IQueryService<T> where T : EntityBase
{
    private readonly IQueryRepository<T> _queryRepository;
    
    public QueryService(IQueryRepository<T> queryRepository)
    {
        _queryRepository = queryRepository;
    }
    
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _queryRepository.GetAllAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _queryRepository.GetByIdAsync(id);
    }
}
