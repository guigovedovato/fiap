using FCG.Domain.Profile;

namespace FCG.Domain.Authentication;

public class LoginModel
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public string Email { get; set; }
    public string Password { get; set; }

    public int UserId { get; set; }

    public virtual UserModel User { get; set; } = null!;
}