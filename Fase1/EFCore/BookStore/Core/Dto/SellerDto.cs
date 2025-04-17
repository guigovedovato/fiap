namespace BookStore.Core.Dto;

public class SellerDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required AddressDto Address { get; set; }
    public ICollection<BookDto> Books { get; set; } = new List<BookDto>();
}