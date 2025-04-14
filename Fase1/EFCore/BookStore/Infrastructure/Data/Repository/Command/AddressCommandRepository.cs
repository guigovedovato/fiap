using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Command;
using BookStore.Infrastructure.Data.Context;

namespace BookStore.Infrastructure.Data.Repository.Command;

public class AddressCommandRepository : CommandRepository<Address>, IAddressCommandRepository
{
    public AddressCommandRepository(CommandDbContext context) : base(context) {}
}