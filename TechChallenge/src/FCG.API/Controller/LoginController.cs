using FCG.Domain.Authentication;

namespace FCG.API.Controller;

public static class LoginController
{
    public static void MapLoginEndpoints(this IEndpointRouteBuilder app)
    {
        var loginGroup = app
            .MapGroup("/login")
            .WithOpenApi();

        loginGroup.MapPost("/", Login);
    }

    static async Task<IResult> Login(LoginRequest loginRequest, ILoginService loginService)
    {
        var loggedUser = await loginService.LoginAsync(loginRequest.ToLoginDto());
        return string.IsNullOrWhiteSpace(loggedUser.Token) ? TypedResults.Unauthorized() : TypedResults.Ok(loggedUser.Token);
    }
}
