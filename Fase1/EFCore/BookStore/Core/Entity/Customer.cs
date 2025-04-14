namespace BookStore.Core.Entity;

public class Customer : EntityBase
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required string AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;
}
