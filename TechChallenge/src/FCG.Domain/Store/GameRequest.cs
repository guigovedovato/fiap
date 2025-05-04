namespace FCG.Domain.Game;

public class GameRequest(string Name, string Description, string ImageUrl, Genre Genre, string Publisher, DateTime ReleaseDate, decimal Price, bool IsDemo = false, bool IsActive = true);