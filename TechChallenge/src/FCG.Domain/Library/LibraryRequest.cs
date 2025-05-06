using MessagePack;

namespace FCG.Domain.Library;

[MessagePackObject]
public class LibraryRequest(int UserId, IEnumerable<LibraryItemRequest> LibraryItems, bool Wishlist = false)
{
    [Key(0)]
    public int UserId { get; set; } = UserId;

    [Key(1)]
    public IEnumerable<LibraryItemRequest> LibraryItems { get; set; } = LibraryItems;

    [Key(2)]
    public bool Wishlist { get; set; } = Wishlist;
}