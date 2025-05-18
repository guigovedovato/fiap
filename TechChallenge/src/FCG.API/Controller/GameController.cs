﻿using FCG.Domain.Common.Response;
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

    static async Task<IResult> UpdateGame(Guid id, GameRequest gameRequest, IGameService _gameService)
    {
        var success = await _gameService.UpdateGameAsync(id, gameRequest.ToGameDto(), new CancellationToken());
        return success is not null ? TypedResults.NoContent() : TypedResults.NotFound();
    }

    static async Task<IResult> GetGame(Guid id, IGameService _GameService)
    {
        var game = await _GameService.GetGameByIdAsync(id, new CancellationToken());

        if (game == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(
            MessagePackSerializer.SerializeToJson(
                new ApiResponse<GameResponse>(game.ToGameResponse(), $"Game {game.Name} found.")));
    }

    static async Task<IResult> GetAllGames(IGameService _gameService, ICacheService _cacheService)
    {
        var key = "GameList";

        if (_cacheService.Get(key) is List<GameResponse> cachedGame)
        {
            return TypedResults.Ok(
                MessagePackSerializer.SerializeToJson(
                    new ApiResponse<List<GameResponse>>(cachedGame, $"Games found.")));
        }

        var gameList = await _gameService.GetAllGamesAsync(new CancellationToken());
        var gameListResponse = gameList.Select(x => x.ToGameResponse()).ToList();

        _cacheService.Set(key, gameListResponse);

        return TypedResults.Ok(
            MessagePackSerializer.SerializeToJson(
                new ApiResponse<List<GameResponse>>(gameListResponse, $"Games found.")));
    }

    static async Task<IResult> CreateGame(GameRequest gameRequest, IGameService _gameService)
    {
        var gameId = await _gameService.CreateGameAsync(gameRequest.ToGameDto(), new CancellationToken());
        return TypedResults.Created($"/Game/{gameId}", gameRequest);
    }

    static async Task<IResult> DeleteGame(Guid id, IGameService _gameService)
    {
        var success = await _gameService.DeleteGameAsync(id, new CancellationToken());
        return success ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}
