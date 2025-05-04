using FCG.Domain.Profile;
using FCG.Domain.Game;

namespace FCG.Domain.Library;

public class LibraryModel
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public bool Wishlist { get; set; }

    public int UserId { get; set; }
    public int LibraryItemModelId { get; set; }

    public virtual UserModel User { get; set; } = null!;
    public virtual LibraryItemModel Item { get; set; } = null!;
}