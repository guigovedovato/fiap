using BookStore.Core.Entity;
using BookStore.Core.Interface.Data;
using BookStore.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data.Repository;

public class CommandRepository<T> : ICommandRepository<T> where T : EntityBase
{
    protected readonly CommandDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public CommandRepository(CommandDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public Task AddAsync(T entity)
    {
        _dbSet.Add(entity);
        return _context.SaveChangesAsync();
    }

    public Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return _context.SaveChangesAsync();
    }

    public Task DeleteAsync(Guid id)
    {
        var entity = _dbSet.Find(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            return _context.SaveChangesAsync();
        }
        return Task.CompletedTask;
    }
}