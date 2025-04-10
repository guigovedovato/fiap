namespace Core.Entity;

public class Client : EntityBase
{
    public required string Name { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Email { get; set; }

    public ICollection<Order>? Orders { get; set; }
}