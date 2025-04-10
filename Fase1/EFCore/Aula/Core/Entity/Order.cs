namespace Core.Entity;

public class Order : EntityBase
{
    public int ClientId { get; set; }
    public int BookId { get; set; }

    public virtual Client Client { get; set; } = null!;
    public virtual Book Book { get; set; } = null!;
}
