using Core.Entity;
using Core.Dto;

namespace Core.Repository;

public interface IClientRepository : IRepository<Client>
{
    Task<ClientDto> GetOrdersByIdAsync(int id);
}
