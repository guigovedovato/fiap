using FCG.Domain.Store;

namespace FCG.Application.Store;

public class GameService : IGameService
{
    public Task<int> CreateGameAsync(GameDto gameDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteGameAsync(int gameId)
    {
        throw new NotImplementedException();
    }

    public Task<List<GameDto>> GetAllGamesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<GameDto> GetGameByIdAsync(int gameId)
    {
        throw new NotImplementedException();
    }

    public Task<GameDto> UpdateGameAsync(int gameId, GameDto gameDto)
    {
        throw new NotImplementedException();
    }
}
