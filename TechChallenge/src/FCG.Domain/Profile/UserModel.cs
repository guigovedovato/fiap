using FCG.Domain.Authentication;

namespace FCG.Domain.Profile;

public class UserModel
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public bool IsActive { get; set; }

    public virtual LoginModel Login { get; set; } = null!;
}