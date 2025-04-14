using BookStore.Core.Entity;
using BookStore.Core.Dto;
using BookStore.Core.Vm;

namespace BookStore.Core.Extensions;

public static class StockExtensions
{
    public static StockDto ToDto(this Stock stock)
    {
        return new StockDto
        {
            Id = stock.Id,
            CreatedAt = stock.CreatedAt,
            UpdatedAt = stock.UpdatedAt,
            Quantity = stock.Quantity,
            BookId = stock.BookId,
            SellerId = stock.SellerId
        };
    }

    public static StockDto ToDto(this StockVm stockVm)
    {
        return new StockDto
        {
            Quantity = stockVm.Quantity,
            BookId = stockVm.BookId,
            SellerId = stockVm.SellerId
        };
    }

    public static Stock ToEntity(this StockDto stock)
    {
        return new Stock
        {
            Quantity = stock.Quantity,
            BookId = stock.BookId,
            SellerId = stock.SellerId
        };
    }

    public static StockVm ToVm(this StockDto stock)
    {
        return new StockVm
        {
            Id = stock.Id,
            CreatedAt = stock.CreatedAt,
            UpdatedAt = stock.UpdatedAt,
            Quantity = stock.Quantity,
            BookId = stock.BookId,
            SellerId = stock.SellerId
        };
    }
}