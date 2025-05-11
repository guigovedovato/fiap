using MessagePack;

namespace FCG.Domain.Store;

[MessagePackObject]
public class GameRequest(string Name, string Description, string ImageUrl, Genre Genre, string Publisher, DateTime ReleaseDate, decimal Price, bool IsDemo = false, bool IsActive = true)
{
    [Key(0)]
    public string Name { get; set; } = Name;

    [Key(1)]
    public string Description { get; set; } = Description;

    [Key(2)]
    public string ImageUrl { get; set; } = ImageUrl;

    [Key(3)]
    public Genre Genre { get; set; } = Genre;

    [Key(4)]
    public string Publisher { get; set; } = Publisher;

    [Key(5)]
    public DateTime ReleaseDate { get; set; } = ReleaseDate;

    [Key(6)]
    public decimal Price { get; set; } = Price;

    [Key(7)]
    public bool IsDemo { get; set; } = IsDemo;

    [Key(8)]
    public bool IsActive { get; set; } = IsActive;

    public GameDto ToGameDto()
    {
        throw new NotImplementedException();
    }
}