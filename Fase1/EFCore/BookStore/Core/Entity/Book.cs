namespace BookStore.Core.Entity;

public class Book : EntityBase
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string ISBN { get; set; }
    public required decimal Price { get; set; }

    public virtual Stock Stock { get; set; } = null!;
    public virtual Seller Seller { get; set; } = null!;
}