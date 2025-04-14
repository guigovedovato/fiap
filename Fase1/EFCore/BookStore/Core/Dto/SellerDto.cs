namespace BookStore.Core.Dto;

public class SellerDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string AddressId { get; set; }
    public ICollection<Guid> BooksId { get; set; } = new List<Guid>();

    public ICollection<BookDto> Books { get; set; } = null!;
    public AddressDto Address { get; set; } = null!;
    public ICollection<StockDto> Stocks { get; set; } = null!;
}