using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Data.Query;

public interface IAddressQueryRepository : IQueryRepository<Address>
{
    Task<Address> GetByCustomerIdAsync(Guid customerId);
    Task<Address> GetBySellerIdAsync(Guid sellerId);
}