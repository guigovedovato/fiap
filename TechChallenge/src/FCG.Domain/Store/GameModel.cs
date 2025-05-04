using FCG.Domain.Library;

namespace FCG.Domain.Game;

public class GameModel
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public Genre Genre { get; set; }
    public bool IsDemo { get; set; }
    public string Publisher { get; set; }
    public DateTime ReleaseDate { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }

    public int LibraryId { get; set; }

    public virtual LibraryModel Library { get; set; } = null!;
}