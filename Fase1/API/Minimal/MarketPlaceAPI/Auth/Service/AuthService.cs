using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MarketPlaceAPI.Auth.Interface;
using MarketPlaceAPI.Auth.Model;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlaceAPI.Auth.Service;

public class AuthService(IConfiguration _configuration) : IAuthService
{
    public Task<string> LoginAsync(LoginModel loginModel)
    {
        if (loginModel.User.Equals("admin") && loginModel.Password.Equals("admin"))
        {
            return Task.FromResult(GenerateToken(loginModel.User, "Admin"));
        }
        else if (loginModel.User.Equals("user") && loginModel.Password.Equals("user"))
        {
            return Task.FromResult(GenerateToken(loginModel.User, "User"));
        }
        else
        {
            return Task.FromResult(string.Empty);
        }
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