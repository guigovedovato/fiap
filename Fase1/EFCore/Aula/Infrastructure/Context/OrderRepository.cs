using Core.Entity;
using Core.Repository;

namespace Infrastructure.Context;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(ApplicationDbContext context) : base(context) {}
}
