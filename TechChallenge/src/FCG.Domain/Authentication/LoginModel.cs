using FCG.Domain.Common;
using FCG.Domain.Profile;

namespace FCG.Domain.Authentication;

public class LoginModel : EntityBase
{
    public required string Email { get; set; }
    public required string Password { get; set; }

    public virtual UserModel User { get; set; } = null!;
}