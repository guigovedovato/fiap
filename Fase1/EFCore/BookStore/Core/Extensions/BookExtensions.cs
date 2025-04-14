using BookStore.Core.Entity;
using BookStore.Core.Dto;
using BookStore.Core.Vm;

namespace BookStore.Core.Extensions;

public static class BookExtensions
{
    public static BookDto ToDto(this Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            CreatedAt = book.CreatedAt,
            UpdatedAt = book.UpdatedAt,
            Title = book.Title,
            Author = book.Author,
            Price = book.Price,
            ISBN = book.ISBN
        };
    }

    public static BookDto ToDto(this BookVm bookVm)
    {
        return new BookDto
        {
            Title = bookVm.Title,
            Author = bookVm.Author,
            Price = bookVm.Price,
            ISBN = bookVm.ISBN
        };
    }

    public static Book ToEntity(this BookDto book)
    {
        return new Book
        {
            Title = book.Title,
            Author = book.Author,
            Price = book.Price,
            ISBN = book.ISBN
        };
    }

    public static BookVm ToVm(this BookDto book)
    {
        return new BookVm
        {
            Id = book.Id,
            CreatedAt = book.CreatedAt,
            UpdatedAt = book.UpdatedAt,
            Title = book.Title,
            Author = book.Author,
            Price = book.Price,
            ISBN = book.ISBN
        };
    }
}