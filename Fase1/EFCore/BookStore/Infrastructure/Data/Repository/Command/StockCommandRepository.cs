using BookStore.Core.Entity;
using BookStore.Core.Interface.Data.Command;
using BookStore.Infrastructure.Data.Context;

namespace BookStore.Infrastructure.Data.Repository.Command;

public class StockCommandRepository : CommandRepository<Stock>, IStockCommandRepository
{
    public StockCommandRepository(CommandDbContext context) : base(context) {}
}