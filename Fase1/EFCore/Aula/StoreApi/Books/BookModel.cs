namespace StoreApi.Books;

public class BookModel
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Publisher { get; set; }
}
