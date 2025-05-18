namespace FCG.Domain.Store;

public interface IGameService
{
    Task<GameDto> GetGameByIdAsync(Guid gameId, CancellationToken cancellationToken);
    Task<IEnumerable<GameDto>> GetAllGamesAsync(CancellationToken cancellationToken);
    Task<Guid> CreateGameAsync(GameDto gameDto, CancellationToken cancellationToken);
    Task<bool> DeleteGameAsync(Guid gameId, CancellationToken cancellationToken);
    Task<GameDto> UpdateGameAsync(Guid gameId, GameDto gameDto, CancellationToken cancellationToken);
    Task<IEnumerable<GameDto>> GetGameByFilterAsync(Filter filter, CancellationToken cancellationToken);
}
