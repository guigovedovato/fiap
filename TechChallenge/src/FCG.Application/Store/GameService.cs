using FCG.Domain.Store;
using FCG.Infrastructure.Data.Repository;
using FCG.Infrastructure.Log;

namespace FCG.Application.Store;

public class GameService(IGameRepository _gameRepository, BaseLogger _logger) : IGameService
{
    public async Task<Guid> CreateGameAsync(GameDto gameDto, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Creating game: {gameDto.Name}");
        var gameModel = gameDto.ToGameModel();
        var response = await _gameRepository.AddAsync(gameModel, cancellationToken);
        return response.Id;
    }

    public async Task<bool> DeleteGameAsync(Guid gameId, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Deleting game with ID: {gameId}");
        return await _gameRepository.DeleteAsync(gameId, cancellationToken);
    }

    public async Task<IEnumerable<GameDto>> GetAllGamesAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching all games");
        var games = await _gameRepository.GetAllAsync(cancellationToken);
        return games.Select(game => game.ToGameDto());
    }

    public async Task<IEnumerable<GameDto>> GetGameByFilterAsync(Filter filter, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Fetching games with filter: {filter}");
        var games = await _gameRepository.GetGameByFilterAsync(filter, cancellationToken);
        return games.Select(game => game.ToGameDto());
    }

    public async Task<GameDto> GetGameByIdAsync(Guid gameId, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Fetching game with ID: {gameId}");
        var game = await _gameRepository.GetByIdAsync(gameId, cancellationToken);
        return game.ToGameDto();
    }

    public async Task<GameDto> UpdateGameAsync(Guid gameId, GameDto gameDto, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Updating game with ID: {gameId}");
        var gameModel = gameDto.ToGameModel();
        gameModel.Id = gameId;
        var response = await _gameRepository.UpdateAsync(gameId, gameModel, cancellationToken);
        return response.ToGameDto();
    }
}
