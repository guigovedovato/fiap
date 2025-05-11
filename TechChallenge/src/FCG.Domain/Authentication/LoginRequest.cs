using MessagePack;

namespace FCG.Domain.Authentication;

[MessagePackObject]
public class LoginRequest(string Email, string Password)
{
    [Key(0)]
    public string Email { get; set; } = Email;

    [Key(1)]
    public string Password { get; set; } = Password;

    public LoginDto ToLoginDto()
    {
        return new LoginDto
        {
            Email = Email,
            Password = Password
        };
    }
}