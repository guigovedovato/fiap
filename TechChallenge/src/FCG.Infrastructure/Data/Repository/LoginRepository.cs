using FCG.Domain.Authentication;
using FCG.Infrastructure.Data.Context;
using FCG.Infrastructure.Log;

namespace FCG.Infrastructure.Data.Repository;

public class LoginRepository(ApplicationDbContext _context, BaseLogger _logger) : Repository<LoginModel>(_context, _logger), ILoginRepository
{
}
