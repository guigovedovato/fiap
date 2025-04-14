using BookStore.Core.Entity;

namespace BookStore.Core.Interface.Service.Query;

public interface IAddressQueryService : IQueryService<Address>
{
    Task<Address?> GetByCustomerIdAsync(Guid customerId);
    Task<Address?> GetBySellerIdAsync(Guid sellerId);
}