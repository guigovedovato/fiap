namespace Core.Dto;

public class BookDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public required string Title { get; set; }
    public required string Publisher { get; set; }

    public ICollection<OrderDto> Orders { get; set; } = null!;
}