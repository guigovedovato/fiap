namespace BookStore.Core.Dto;

public class AddressDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
    public required string Country { get; set; }

    public SellerDto Seller { get; set; } = null!;
    public CustomerDto Customer { get; set; } = null!;
}