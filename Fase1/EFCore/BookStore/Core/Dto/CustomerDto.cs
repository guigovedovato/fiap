namespace BookStore.Core.Dto;

public class CustomerDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string AddressId { get; set; }

    public AddressDto Address { get; set; } = null!;
}
