using Core.Repository;
using Core.Entity;
using Core.Dto;

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
        bookGroup.MapPost("/bulk/", AddBulkBooks);
    }

    private static async Task<IResult> GetAllBooks(IBookRepository bookRepository)
    {
        var booksDto = new List<BookDto>();
        var books = await bookRepository.GetAllAsync();

        foreach (var book in books)
        {
            booksDto.Add(new BookDto
            {
                Id = book.Id,
                CreatedAt = book.CreatedAt,
                Title = book.Title,
                Publisher = book.Publisher,
                Orders = book.Orders.Select(o =>
                    new OrderDto
                    {
                        ClientId = o.ClientId,
                        BookId = o.BookId
                    }
                ).ToList()
            });
        }

        return TypedResults.Ok(booksDto);
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

    private static async Task<IResult> AddBulkBooks(IEnumerable<BookModel> bookModels, IBookRepository bookRepository)
    {
        try 
        {
            var books = bookModels.Select(b => new Book
            {
                Title = b.Title,
                Publisher = b.Publisher
            });
            await bookRepository.AddBulkAsync(books);
            return TypedResults.Ok();
        }
        catch (Exception ex)
        {
            return TypedResults.BadRequest(ex.Message);
        }
    }
}