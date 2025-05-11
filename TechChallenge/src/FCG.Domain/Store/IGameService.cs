namespace FCG.Domain.Store;

public interface IGameService
{
    Task<GameDto> GetGameByIdAsync(int gameId);
    Task<List<GameDto>> GetAllGamesAsync();
    Task<int> CreateGameAsync(GameDto gameDto);
    Task<bool> DeleteGameAsync(int gameId);
    Task<GameDto> UpdateGameAsync(int gameId, GameDto gameDto);
    Task<List<GameResponse>> GetGameByFilterAsync(string filter);
}
