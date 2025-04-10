using Core.Entity;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using Core.Dto;

namespace Infrastructure.Context;

public class ClientRepository : Repository<Client>, IClientRepository
{
    public ClientRepository(ApplicationDbContext context) : base(context) {}

    public Task<ClientDto> GetOrdersByIdAsync(int id)
    {
        var client = _context.Clients
                        .FirstOrDefault(c => c.Id == id)
                        ?? throw new Exception($"Client with id {id} not found");
        return Task.FromResult(new ClientDto
        {
            Id = client.Id,
            CreatedAt = client.CreatedAt,
            Name = client.Name,
            BirthDate = client.BirthDate,
            Email = client.Email,
            Orders = client.Orders.Select(o =>
                new OrderDto
                {
                    ClientId = o.ClientId,
                    BookId = o.BookId
                }
            ).ToList()
        });
    }
}