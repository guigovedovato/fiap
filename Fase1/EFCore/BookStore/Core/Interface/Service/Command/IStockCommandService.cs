using BookStore.Core.Dto;

namespace BookStore.Core.Interface.Service.Command;

public interface IStockCommandService
{
    Task AddAsync(StockDto stockDto);
    Task UpdateAsync(StockDto stockDto);
    Task DeleteAsync(Guid id);
}