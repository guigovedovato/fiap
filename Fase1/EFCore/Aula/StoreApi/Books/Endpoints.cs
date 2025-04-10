using Core.Repository;
using Core.Entity;

namespace StoreApi.Books;

public static class Endpoints
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

    private static async Task<IResult> GetAllBooks(IBookRepository bookRepository)
    {
        var books = await bookRepository.GetAllAsync();
        return TypedResults.Ok(books);
    }

    private static async Task<IResult> GetBookById(int id, IBookRepository bookRepository)
    {
        var book = await bookRepository.GetByIdAsync(id);
        return book is not null ? TypedResults.Ok(book) : TypedResults.NotFound();
    }

    private static async Task<IResult> CreateBook(BookModel bookModel, IBookRepository bookRepository)
    {
        try 
        {
            await bookRepository.AddAsync(new Book{
                Title = bookModel.Title,
                Publisher = bookModel.Publisher
            });
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> UpdateBook(BookModel bookModel, IBookRepository bookRepository)
    {
        try 
        {
            var book = await bookRepository.GetByIdAsync(bookModel.Id);
            if (book is null)
            {
                return TypedResults.NotFound();
            }
            book.Title = bookModel.Title;
            book.Publisher = bookModel.Publisher;
            await bookRepository.UpdateAsync(book);
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> DeleteBook(int id, IBookRepository bookRepository)
    {
        try 
        {
            var book = await bookRepository.GetByIdAsync(id);
            if (book is null)
            {
                return TypedResults.NotFound();
            }
            await bookRepository.DeleteAsync(book.Id);
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }
}