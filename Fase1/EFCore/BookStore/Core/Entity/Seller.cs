namespace BookStore.Core.Entity;

public class Seller : EntityBase
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string AddressId { get; set; }
    public ICollection<Guid> BooksId { get; set; } = new List<Guid>();

    public virtual Address Address { get; set; } = null!;
    public virtual ICollection<Book> Books { get; set; } = null!;
    
    public virtual ICollection<Stock> Stocks { get; set; } = null!;
}