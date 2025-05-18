﻿using FCG.Domain.Store;
using FCG.Infrastructure.Data.Context;
using FCG.Infrastructure.Log;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infrastructure.Data.Repository;

public class GameRepository(ApplicationDbContext _context, BaseLogger _logger) : Repository<GameModel>(_context, _logger), IGameRepository
{
    public async Task<IEnumerable<GameModel>> GetGameByFilterAsync(Filter filter, CancellationToken cancellationToken)
    {
        try
        {
            // TODO: Implement filtering logic here
            return await _dbSet.ToListAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving all filtered Games: {ex.Message}");
            throw;
        }
    }
}
