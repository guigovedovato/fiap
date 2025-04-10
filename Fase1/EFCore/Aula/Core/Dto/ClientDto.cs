namespace Core.Dto;

public class ClientDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public required string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Email { get; set; }

    public ICollection<OrderDto> Orders { get; set; } = null!;
}