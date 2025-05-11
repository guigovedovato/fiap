using FCG.Domain.Store;

namespace FCG.Domain.Library;

public class LibraryItemModel
{
    public int Id { get; set; }

    public virtual IEnumerable<GameModel> Games { get; set; } = null!;
}