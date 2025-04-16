using BookStore.Core.Dto;

namespace BookStore.Core.Interface.Service.Query;

public interface IAddressQueryService
{
    Task<IEnumerable<AddressDto>> GetAllAsync();
    Task<AddressDto?> GetByIdAsync(Guid id);
    Task<AddressDto?> GetByCustomerIdAsync(Guid customerId);
    Task<AddressDto?> GetBySellerIdAsync(Guid sellerId);
}