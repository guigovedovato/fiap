using BookStore.Core.Dto;

namespace BookStore.Core.Interface.Service.Query;

public interface ISellerQueryService
{
    Task<IEnumerable<SellerDto>> GetAllAsync();
    Task<SellerDto?> GetByIdAsync(Guid id);
}