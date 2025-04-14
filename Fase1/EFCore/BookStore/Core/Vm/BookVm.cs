namespace BookStore.Core.Vm;

public class BookVm
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public decimal Price { get; set; }
}