using FCG.Domain.Authentication;
using FCG.Infrastructure.Data.Context;
using FCG.Infrastructure.Log;
using Microsoft.EntityFrameworkCore;

namespace FCG.Infrastructure.Data.Repository;

public class LoginRepository(ApplicationDbContext _context, BaseLogger _logger) : Repository<LoginModel>(_context, _logger), ILoginRepository
{
    public async Task<bool> ExistsAsync(string email, CancellationToken cancellationToken)
    {
        try
        {
            LoginModel? entity = await _dbSet.FirstOrDefaultAsync(x => x.Email.Equals(email), cancellationToken: cancellationToken);
            if (entity == null)
            {
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error retrieving {typeof(LoginModel)} with email {email}: {ex.Message}");
            throw;
        }
    }
}
