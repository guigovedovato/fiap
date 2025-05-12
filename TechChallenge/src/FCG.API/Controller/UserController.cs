using FCG.Domain.Profile;
using FCG.Infrastructure.Cache;
using MessagePack;

namespace FCG.API.Controller;

public static class UserController
{
    public static void MapUserEndpoints(this IEndpointRouteBuilder app)
    {
        var userGroup = app
            .MapGroup("/user");

        userGroup.MapGet("/", GetAllUsers).CacheOutput(policy =>
        {
            policy.SetVaryByRouteValue("allUsers");
            policy.Expire(TimeSpan.FromMinutes(10));
        }).RequireAuthorization("Admin");
        userGroup.MapGet("/{id}", GetUser).CacheOutput(policy =>
        {
            policy.SetVaryByRouteValue("user");
            policy.Expire(TimeSpan.FromMinutes(10));
        }).RequireAuthorization();
        userGroup.MapPost("/", CreateUser).RequireAuthorization("Admin");
        userGroup.MapDelete("/{id}", DeleteUser).RequireAuthorization("Admin");
        userGroup.MapPut("/{id}", UpdateUser).RequireAuthorization("Admin");
    }

    static async Task<IResult> UpdateUser(int id, UserRequest userRequest, IUserService _userService)
    {
        var success = await _userService.UpdateUserAsync(id, userRequest.ToUserDto());
        return success is not null ? TypedResults.NoContent() : TypedResults.NotFound();
    }

    static async Task<IResult> GetUser(int id, IUserService _userService)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(MessagePackSerializer.SerializeToJson(user.ToUserResponse()));
    }

    static async Task<IResult> GetAllUsers(IUserService _userService, ICacheService _cacheService)
    {
        var key = "UserList";

        if (_cacheService.Get(key) is List<string> cachedUser)
        {
            return TypedResults.Ok(MessagePackSerializer.SerializeToJson(cachedUser));
        }

        var userList = await _userService.GetAllUsersAsync();
        var userResponseList = userList.Select(user => user.ToUserResponse()).ToList();

        _cacheService.Set(key, userResponseList);

        return TypedResults.Ok(MessagePackSerializer.SerializeToJson(userResponseList));
    }

    static async Task<IResult> CreateUser(UserRequest userRequest, IUserService _userService)
    {
        var userId = await _userService.CreateUserAsync(userRequest.ToUserDto());
        return TypedResults.Created($"/user/{userId}", userRequest);
    }

    static async Task<IResult> DeleteUser(int id, IUserService _userService)
    {
        var success = await _userService.DeleteUserAsync(id);
        return success ? TypedResults.NoContent() : TypedResults.NotFound();
    }
}
