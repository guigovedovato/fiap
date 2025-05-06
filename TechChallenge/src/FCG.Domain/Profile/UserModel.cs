using FCG.Domain.Authentication;

namespace FCG.Domain.Profile;

public class UserModel
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Role { get; set; }
    public bool IsActive { get; set; }

    public virtual LoginModel Login { get; set; } = null!;
}