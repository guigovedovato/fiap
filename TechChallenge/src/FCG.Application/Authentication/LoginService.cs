using FCG.Domain.Authentication;
using FCG.Infrastructure.Authentication;

namespace FCG.Application.Authentication;

public class LoginService(IJwtTokenGenerator _jwtGenerator) : ILoginService
{
    // TODO: Implement a real authentication service
    public async Task<LoginDto> LoginAsync(LoginDto loginDto)
    {
        if (loginDto.Email.Equals("admin") && loginDto.Password.Equals("admin"))
        {
            var loggedUer = new LoginDto
            {
                Email = loginDto.Email,
                Token = await _jwtGenerator.GenerateTokenAsync(loginDto.Email, "Admin")
            };
            return loggedUer;
        }
        else if (loginDto.Email.Equals("user") && loginDto.Password.Equals("user"))
        {
            var loggedUer = new LoginDto
            {
                Email = loginDto.Email,
                Token = await _jwtGenerator.GenerateTokenAsync(loginDto.Email, "User")
            };
            return loggedUer;
        }
        else
        {
            return default!;
        }
    }

    public Task<LoginDto> LogoutAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }
}
