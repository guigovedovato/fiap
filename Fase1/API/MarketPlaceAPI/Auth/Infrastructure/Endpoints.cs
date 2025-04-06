using MarketPlaceAPI.Auth.Interface;
using MarketPlaceAPI.Auth.Model;

namespace MarketPlaceAPI.Auth.Infrastructure;

    public static class Endpoints
    {
        public static void MapAuthEndpoints(this WebApplication app)
        {
            var authGroup = app.MapGroup("/auth");

            authGroup.MapPost("/login", Login);
        }

        static async Task<IResult> Login(LoginModel loginModel, IAuthService authService)
        {
            var token = await authService.LoginAsync(loginModel);
            return string.IsNullOrWhiteSpace(token) ? TypedResults.Unauthorized() : TypedResults.Ok(token);
        }
    }