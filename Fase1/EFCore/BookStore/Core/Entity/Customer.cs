namespace BookStore.Core.Entity;

public class Customer : EntityBase
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public virtual required Address Address { get; set; }
}
