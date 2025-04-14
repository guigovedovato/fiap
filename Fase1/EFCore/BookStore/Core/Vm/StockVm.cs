namespace BookStore.Core.Vm;

public class StockVm
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid BookId { get; set; }
    public Guid SellerId { get; set; }
    public int Quantity { get; set; }
}