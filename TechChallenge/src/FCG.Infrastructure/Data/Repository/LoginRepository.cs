using FCG.Domain.Authentication;
using FCG.Infrastructure.Data.Context;

namespace FCG.Infrastructure.Data.Repository;

public class LoginRepository(ApplicationDbContext context) : Repository<LoginModel>(context), ILoginRepository
{
}
