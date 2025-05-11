using FCG.Domain.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FCG.Application.Authentication;

public class LoginService(IConfiguration _configuration) : ILoginService
{
    // TODO: Implement a real authentication service
    public Task<LoginDto> LoginAsync(LoginDto loginDto)
    {
        if (loginDto.Email.Equals("admin") && loginDto.Password.Equals("admin"))
        {
            var loggedUer = new LoginDto
            {
                Email = loginDto.Email,
                Token = GenerateToken(loginDto.Email, "Admin")
            };
            return Task.FromResult(loggedUer);
        }
        else if (loginDto.Email.Equals("user") && loginDto.Password.Equals("user"))
        {
            var loggedUer = new LoginDto
            {
                Email = loginDto.Email,
                Token = GenerateToken(loginDto.Email, "User")
            };
            return Task.FromResult(loggedUer);
        }
        else
        {
            return Task.FromResult(default(LoginDto)!);
        }
    }

    public Task<LoginDto> LogoutAsync(LoginDto loginDto)
    {
        throw new NotImplementedException();
    }

    private string GenerateToken(string username, string role)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var secretKey = jwtSettings["SecretKey"];
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];

        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, username),
        new Claim(ClaimTypes.Role, role),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds,
            audience: audience
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
