using BookStore.Core.Entity;
using BookStore.Core.Interface.Data;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repository;

public class QueryRepository<T> : IQueryRepository<T> where T : EntityBase
{
    protected readonly QueryDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public QueryRepository(QueryDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public Task<IEnumerable<T>> GetAllAsync()
        => Task.FromResult(_dbSet.AsEnumerable());

    public Task<T> GetByIdAsync(Guid id)
        => Task.FromResult(_dbSet.Find(id) 
                           ?? throw new Exception($"Entity with id {id} not found"));
}