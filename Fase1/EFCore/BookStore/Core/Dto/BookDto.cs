namespace BookStore.Core.Dto;

public class BookDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public required decimal Price { get; set; }

    public StockDto Stock { get; set; } = null!;
    public SellerDto Seller { get; set; } = null!;
}