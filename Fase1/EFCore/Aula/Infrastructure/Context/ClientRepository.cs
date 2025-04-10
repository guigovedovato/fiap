using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(ApplicationDbContext context) : base(context) {}

    public Task<Client> GetOrdersByIdAsync(int id)
    {
        var client = _context.Clients
                        .AsNoTracking()
                        .Include(c => c.Orders)
                        .ThenInclude(o => o.Book)
                        .FirstOrDefault(c => c.Id == id)
                        ?? throw new Exception($"Client with id {id} not found");
        return Task.FromResult(client);
    }
}