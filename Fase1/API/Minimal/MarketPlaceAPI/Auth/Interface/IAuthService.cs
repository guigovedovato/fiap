using MarketPlaceAPI.Auth.Model;

namespace MarketPlaceAPI.Auth.Interface;

public interface IAuthService
{
    Task<string> LoginAsync(LoginModel loginModel);
}