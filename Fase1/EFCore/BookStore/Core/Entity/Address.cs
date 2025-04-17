namespace BookStore.Core.Entity;

public class Address : EntityBase
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public required string ZipCode { get; set; }
    public required string Country { get; set; }

    public Guid CustomerId { get; set; }
    public Guid SellerId { get; set; }
    public virtual Seller Seller { get; set; } = null!;
    public virtual Customer Customer { get; set; } = null!;
}