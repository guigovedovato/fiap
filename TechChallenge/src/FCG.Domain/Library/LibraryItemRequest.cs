using MessagePack;

namespace FCG.Domain.Library;

[MessagePackObject]
public class LibraryItemRequest(int GameId)
{
    [Key(0)]
    public int GameId { get; set; } = GameId;
}