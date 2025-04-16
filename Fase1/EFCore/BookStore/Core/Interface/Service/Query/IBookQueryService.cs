using BookStore.Core.Dto;

namespace BookStore.Core.Interface.Service.Query;

public interface IBookQueryService
{
    Task<IEnumerable<BookDto>> GetAllAsync();
    Task<BookDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<BookDto>> GetBySellerIdAsync(Guid sellerId);
    Task<BookDto?> GetByStockIdAsync(Guid stockId);
}