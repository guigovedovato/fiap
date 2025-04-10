namespace Core.Entity;

public class Order : EntityBase
{
    public int ClientId { get; set; }
    public int BookId { get; set; }

    public Client Client { get; set; } = null!;
    public Book Book { get; set; } = null!;
}
