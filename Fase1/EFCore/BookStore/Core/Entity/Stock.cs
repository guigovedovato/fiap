namespace BookStore.Core.Entity;

public class Stock : EntityBase
{
    public required Guid BookId { get; set; }
    public required Guid SellerId { get; set; }
    public required int Quantity { get; set; }

    public virtual Seller Seller { get; set; } = null!;
    public virtual Book Book { get; set; } = null!;
}