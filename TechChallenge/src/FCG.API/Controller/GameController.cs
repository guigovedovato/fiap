using FCG.Domain.Store;
using FCG.Infrastructure.Cache;
using MessagePack;

namespace FCG.API.Controller;

public static class GameController
{
    public static void MapGameEndpoints(this IEndpointRouteBuilder app)
    {
        var gameGroup = app
            .MapGroup("/game")
            .WithOpenApi();

        gameGroup.MapGet("/", GetAllGames).CacheOutput(policy =>
        {
            policy.SetVaryByRouteValue("allGames");
            policy.Expire(TimeSpan.FromMinutes(10));
        }).RequireAuthorization();
        gameGroup.MapGet("/{id}", GetGame).CacheOutput(policy =>
        {
            policy.SetVaryByRouteValue("Game");
            policy.Expire(TimeSpan.FromMinutes(10));
        }).RequireAuthorization();
        gameGroup.MapPost("/", CreateGame).RequireAuthorization("Admin");
        gameGroup.MapDelete("/{id}", DeleteGame).RequireAuthorization("Admin");
        gameGroup.MapPut("/{id}", UpdateGame).RequireAuthorization("Admin");
    }

    static async Task<IResult> UpdateGame(int id, GameRequest gameRequest, IGameService _gameService)
    {
        var success = await _gameService.UpdateGameAsync(id, gameRequest.ToGameDto());
        return success is not null ? TypedResults.NoContent() : TypedResults.NotFound();
    }

    static async Task<IResult> GetGame(int id, IGameService _GameService)
    {
        var Game = await _GameService.GetGameByIdAsync(id);

        if (Game == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(MessagePackSerializer.SerializeToJson(Game.ToGameResponse()));
    }

    static async Task<IResult> GetAllGames(IGameService _gameService, ICacheService _cacheService)
    {
        var key = "GameList";

        if (_cacheService.Get(key) is List<string> cachedGame)
        {
            return TypedResults.Ok(MessagePackSerializer.SerializeToJson(cachedGame));
        }

        var gameList = await _gameService.GetAllGamesAsync();
        var gameListResponse = gameList.Select(x => x.ToGameResponse()).ToList();

        _cacheService.Set(key, gameListResponse);

        return TypedResults.Ok(MessagePackSerializer.SerializeToJson(gameListResponse));
    }

    static async Task<IResult> CreateGame(GameRequest gameRequest, IGameService _gameService)
    {
        var GameId = await _gameService.CreateGameAsync(gameRequest.ToGameDto());
        return TypedResults.Created($"/Game/{GameId}", gameRequest);
    }

    static async Task<IResult> DeleteGame(int id, IGameService _gameService)
    {
        var success = await _gameService.DeleteGameAsync(id);
        return success ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}
