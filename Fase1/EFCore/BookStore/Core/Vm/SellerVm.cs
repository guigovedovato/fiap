namespace BookStore.Core.Vm;

public class SellerVm
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Phone { get; set; }
    public required AddressVm Address { get; set; }
    public ICollection<BookVm> Books { get; set; } = new List<BookVm>();
}