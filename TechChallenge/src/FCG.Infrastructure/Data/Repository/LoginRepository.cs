using FCG.Domain.Authentication;
using FCG.Infrastructure.Data.Context;
using FCG.Infrastructure.Log;

namespace FCG.Infrastructure.Data.Repository;

public class LoginRepository(ApplicationDbContext context, BaseLogger baseLogger) : Repository<LoginModel>(context, baseLogger), ILoginRepository
{
}
