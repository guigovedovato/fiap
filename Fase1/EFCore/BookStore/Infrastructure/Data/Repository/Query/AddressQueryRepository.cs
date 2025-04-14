using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Query;
using BookStore.Infrastructure.Data.Context;

namespace BookStore.Infrastructure.Data.Repository.Query;

public class AddressQueryRepository : QueryRepository<Address>, IAddressQueryRepository
{
    public AddressQueryRepository(QueryDbContext context) : base(context) {}

    public Task<Address> GetByCustomerIdAsync(Guid customerId)
    {
        return Task.FromResult(null as Address);
    }

    public Task<Address> GetBySellerIdAsync(Guid sellerId)
    {
        return Task.FromResult(null as Address);
    }
}