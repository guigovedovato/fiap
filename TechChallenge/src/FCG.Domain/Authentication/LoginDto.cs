using FCG.Domain.Profile;

namespace FCG.Domain.Authentication;

public class LoginDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string Token { get; set; } = null!;
    public Guid CorrelationId { get; set; }

    public UserDto User { get; set; } = null!;
}