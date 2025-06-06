using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class Repository<T> : IRepository<T> where T : EntityBase
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public Task AddAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow;
        _dbSet.Add(entity);
        return _context.SaveChangesAsync();
    }

    public Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return _context.SaveChangesAsync();
    }

    public Task DeleteAsync(int id)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            return _context.SaveChangesAsync();
        }
        return Task.CompletedTask;
    }

    public Task<T> GetByIdAsync(int id)
        => Task.FromResult(_dbSet.Find(id) 
                           ?? throw new Exception($"Entity with id {id} not found"));

    public Task<IEnumerable<T>> GetAllAsync()
        => Task.FromResult(_dbSet.AsEnumerable());
}