using BookStore.Core.Dto;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Interface.Data.Query;
using BookStore.Core.Extensions;

namespace BookStore.Service.Query;

public class AddressQueryService : IAddressQueryService
{
    private readonly IAddressQueryRepository _repository;

    public AddressQueryService(IAddressQueryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<AddressDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        if (entities is null) return Enumerable.Empty<AddressDto>();
        return entities.Select(e => e.ToDto());
    }

    public async Task<AddressDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        if (entity is null) return null;
        return entity.ToDto();
    }

    public async Task<AddressDto?> GetByCustomerIdAsync(Guid customerId)
    {
        var entity = await _repository.GetByCustomerIdAsync(customerId);
        if (entity is null) return null;
        return entity.ToDto();
    }

    public async Task<AddressDto?> GetBySellerIdAsync(Guid sellerId)
    {
        var entity = await _repository.GetBySellerIdAsync(sellerId);
        if (entity is null) return null;
        return entity.ToDto();
    }
}