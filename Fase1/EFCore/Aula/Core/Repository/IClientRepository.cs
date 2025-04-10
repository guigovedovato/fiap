using Core.Entity;

namespace Core.Repository;

public interface IClientRepository : IRepository<Client>
{
    Task<Client> GetOrdersByIdAsync(int id);
}
