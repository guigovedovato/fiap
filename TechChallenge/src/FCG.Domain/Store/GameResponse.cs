namespace FCG.Domain.Game;

public class GameResponse(int Id, DateTime CreatedAt, DateTime UpdatedAt, string Name, string Description, string ImageUrl, Genre Genre, bool IsDemo, string Publisher, DateTime ReleaseDate, decimal Price, bool IsActive);