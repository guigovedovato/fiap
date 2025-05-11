using FCG.API.Service.Cache;
using FCG.Domain.Profile;
using FCG.Domain.Store;
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

    static async Task<IResult> UpdateGame(int id, GameRequest GameRequest, IGameService _GameService)
    {
        var success = await _GameService.UpdateGameAsync(id, GameRequest.ToGameDto());
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

    static async Task<IResult> GetAllGames(IGameService _GameService, ICacheService _cacheService)
    {
        var key = "GameList";

        if (_cacheService.Get(key) is List<string> cachedGame)
        {
            return TypedResults.Ok(MessagePackSerializer.SerializeToJson(cachedGame));
        }

        // TODO: Retrurn to GameResponse
        var GameList = await _GameService.GetAllGamesAsync();

        _cacheService.Set(key, GameList);

        return TypedResults.Ok(MessagePackSerializer.SerializeToJson(GameList));
    }

    static async Task<IResult> CreateGame(GameRequest GameRequest, IGameService _GameService)
    {
        var GameId = await _GameService.CreateGameAsync(GameRequest.ToGameDto());
        return TypedResults.Created($"/Game/{GameId}", GameRequest);
    }

    static async Task<IResult> DeleteGame(int id, IGameService _GameService)
    {
        var success = await _GameService.DeleteGameAsync(id);
        return success ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}
