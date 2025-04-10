namespace Core.Entity;

public class Book : EntityBase
{
    public required string Title { get; set; }
    public required string Publisher { get; set; }

    public ICollection<Order>? Orders { get; set; }
}