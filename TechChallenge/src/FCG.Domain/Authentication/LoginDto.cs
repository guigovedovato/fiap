using FCG.Domain.Profile;

namespace FCG.Domain.Authentication;

public class LoginDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
    public Guid CorrelationId { get; set; }

    public UserDto User { get; set; }
}