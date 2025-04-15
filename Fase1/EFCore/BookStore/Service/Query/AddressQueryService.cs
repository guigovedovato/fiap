using BookStore.Core.Entity;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Interface.Data.Query;

namespace BookStore.Service.Query;

public class AddressQueryService : QueryService<Address>, IAddressQueryService
{
    private readonly IAddressQueryRepository _repository;

    public AddressQueryService(IAddressQueryRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public Task<Address?> GetByCustomerIdAsync(Guid customerId)
    {
        return _repository.GetByCustomerIdAsync(customerId);
    }

    public Task<Address?> GetBySellerIdAsync(Guid sellerId)
    {
        return _repository.GetBySellerIdAsync(sellerId);
    }
}