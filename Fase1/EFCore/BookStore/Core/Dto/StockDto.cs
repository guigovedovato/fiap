namespace BookStore.Core.Dto;

public class StockDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required Guid BookId { get; set; }
    public required Guid SellerId { get; set; }
    public required int Quantity { get; set; }

    public SellerDto Seller { get; set; } = null!;
    public BookDto Book { get; set; } = null!;
}