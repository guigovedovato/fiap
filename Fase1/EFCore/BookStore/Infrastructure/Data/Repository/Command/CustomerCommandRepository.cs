using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Command;
using BookStore.Infrastructure.Data.Context;

namespace BookStore.Infrastructure.Data.Repository.Command;

public class CustomerCommandRepository : CommandRepository<Customer>, ICustomerCommandRepository
{
    public CustomerCommandRepository(CommandDbContext context) : base(context) {}
}