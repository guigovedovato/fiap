using FCG.Domain.Game;

namespace FCG.Domain.Library;

public class LibraryItemModel
{
    public int Id { get; set; }
    public IEnumerable<GameDto> Games { get; set; }
}