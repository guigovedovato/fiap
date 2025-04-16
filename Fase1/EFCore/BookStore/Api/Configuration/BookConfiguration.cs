using BookStore.Core.Interface.Service.Command;
using BookStore.Core.Interface.Service.Query;
using BookStore.Core.Vm;
using BookStore.Core.Dto;
using BookStore.Core.Extensions;

namespace BookStore.Api.Configuration;

public static class BookConfiguration
{
    public static void MapBookEndpoints(this WebApplication app)
    {
        var bookGroup = app.MapGroup("/books");

        bookGroup.MapGet("/", GetAllBooks);
        bookGroup.MapGet("/{id}", GetBookById);
        bookGroup.MapPost("/", CreateBook);
        bookGroup.MapPut("/", UpdateBook);
        bookGroup.MapDelete("/{id}", DeleteBook);
    }

    private static async Task<IResult> GetAllBooks(IBookQueryService bookService)
    {
        var books = await bookService.GetAllAsync();
        return Results.Ok(books);
    }

    private static async Task<IResult> GetBookById(IBookQueryService bookService, Guid id)
    {
        var book = await bookService.GetByIdAsync(id);
        return book is not null ? Results.Ok(book) : Results.NotFound();
    }

    private static async Task<IResult> CreateBook(IBookCommandService bookService, BookVm book)
    {
        await bookService.AddAsync(book.ToDto());
        return Results.Created($"/books/{book.Id}", book);
    }

    private static async Task<IResult> UpdateBook(IBookCommandService bookService, IBookQueryService bookQueryService, BookVm book)
    {
        var existingBook = await bookQueryService.GetByIdAsync(book.Id);
        if (existingBook is null) return Results.NotFound();

        await bookService.UpdateAsync(book.ToDto());
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteBook(IBookCommandService bookService, IBookQueryService bookQueryService, Guid id)
    {
        var existingBook = await bookQueryService.GetByIdAsync(id);
        if (existingBook is null) return Results.NotFound();

        await bookService.DeleteAsync(id);
        return Results.NoContent();
    }
}