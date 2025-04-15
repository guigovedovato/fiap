using BookStore.Core.Entity;
using BookStore.Core.Interface.Service;
using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Data.Command;

namespace BookStore.Service.Command;

public class StockCommandService : CommandService<Stock>, IStockCommandService
{
    public StockCommandService(IStockCommandRepository repository) : base(repository) {}
}