using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Query;
using BookStore.Infrastructure.Data.Context;

namespace BookStore.Infrastructure.Data.Repository.Query;

public class CustomerQueryRepository : QueryRepository<Customer>, ICustomerQueryRepository
{
    public CustomerQueryRepository(QueryDbContext context) : base(context) {}
}