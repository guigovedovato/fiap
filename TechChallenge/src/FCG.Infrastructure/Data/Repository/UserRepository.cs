using FCG.Domain.Profile;
using FCG.Infrastructure.Data.Context;

namespace FCG.Infrastructure.Data.Repository;

public class UserRepository(ApplicationDbContext context) : Repository<UserModel>(context), IUserRepository
{
}
