using FCG.Domain.Profile;
using FCG.Infrastructure.Data.Context;
using FCG.Infrastructure.Log;

namespace FCG.Infrastructure.Data.Repository;

public class UserRepository(ApplicationDbContext context, BaseLogger baseLogger) : Repository<UserModel>(context, baseLogger), IUserRepository
{
}
