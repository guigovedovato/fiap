using BookStore.Core.Dto;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Data.Command;
using BookStore.Core.Extensions;

namespace BookStore.Service.Command;

public class StockCommandService :IStockCommandService
{
    private readonly IStockCommandRepository _repository;

    public StockCommandService(IStockCommandRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(StockDto stockDto)
    {
        await _repository.AddAsync(stockDto.ToEntity());
    }

    public async Task UpdateAsync(StockDto stockDto)
    {
        await _repository.UpdateAsync(stockDto.ToEntity());
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}