namespace FCG.Domain.Authentication;

public interface ILoginService
{
    Task<LoginDto> LoginAsync(LoginDto loginDto);
    Task<LoginDto> LogoutAsync(LoginDto loginDto);
}
