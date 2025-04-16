using BookStore.Core.Dto;

namespace BookStore.Core.Interface.Service.Query;

public interface IStockQueryService
{
    Task<IEnumerable<StockDto>> GetAllAsync();
    Task<StockDto?> GetByIdAsync(Guid id);
    Task<StockDto?> GetByBookIdAsync(Guid bookId);
    Task<IEnumerable<StockDto>> GetBySellerIdAsync(Guid sellerId);
}