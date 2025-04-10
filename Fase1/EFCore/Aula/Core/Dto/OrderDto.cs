namespace Core.Dto;

public class OrderDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ClientId { get; set; }
    public int BookId { get; set; }

    public ClientDto Client { get; set; } = null!;
    public BookDto Book { get; set; } = null!;
}