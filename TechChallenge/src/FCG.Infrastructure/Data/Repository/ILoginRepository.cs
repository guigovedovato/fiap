using FCG.Domain.Authentication;

namespace FCG.Infrastructure.Data.Repository;

public interface ILoginRepository : IRepository<LoginModel>
{
    Task<bool> ExistsAsync(string email, CancellationToken cancellationToken);
}
