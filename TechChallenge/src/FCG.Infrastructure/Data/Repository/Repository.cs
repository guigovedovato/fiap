using FCG.Domain.Common;
using FCG.Domain.Common.Exceptions;
using FCG.Infrastructure.Data.Context;
using FCG.Infrastructure.Log;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infrastructure.Data.Repository;

public class Repository<T>(ApplicationDbContext context, BaseLogger baseLogger) : IRepository<T> where T : EntityBase
{
    protected readonly BaseLogger _logger = baseLogger;
    protected readonly ApplicationDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T> AddAsync(T entity)
    {
        try
        {
            entity.CreatedAt = DateTime.UtcNow;
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"{typeof(T)} added successfully.");

            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error adding {typeof(T)}: {ex.Message}");
            throw;
        }
    }

    public async Task<T?> UpdateAsync(Guid id, T entity)
    {
        try
        {
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity == null)
            {
                _logger.LogWarning($"{typeof(T)} with ID {id} not found.");
                throw new EntityDoesNotExistException(id, typeof(T));
            }

            entity.Id = id;
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error updating {typeof(T)}: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                _logger.LogWarning($"{typeof(T)} with ID {id} not found.");
                throw new EntityDoesNotExistException(id, typeof(T));
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"{typeof(T)} with ID {id} deleted successfully.");

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error deleting {typeof(T)}: {ex.Message}");
            throw;
        }
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        try
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                _logger.LogWarning($"{typeof(T)} with ID {id} not found.");
                throw new EntityDoesNotExistException(id, typeof(T));
            }

            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving {typeof(T)} with ID {id}: {ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving all {typeof(T)}: {ex.Message}");
            throw;
        }
    }
}
