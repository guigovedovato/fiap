using MessagePack;

namespace FCG.Domain.Profile;

[MessagePackObject]
public class UserResponse(int Id, DateTime CreatedAt, DateTime UpdatedAt, string FirstName, string LastName, string Role, string Email, bool IsActive)
{
    [Key(0)]
    public int Id { get; set; } = Id;

    [Key(1)]
    public DateTime CreatedAt { get; set; } = CreatedAt;

    [Key(2)]
    public DateTime UpdatedAt { get; set; } = UpdatedAt;

    [Key(3)]
    public string FirstName { get; set; } = FirstName;

    [Key(4)]
    public string LastName { get; set; } = LastName;

    [Key(5)]
    public string Role { get; set; } = Role;

    [Key(6)]
    public string Email { get; set; } = Email;

    [Key(7)]
    public bool IsActive { get; set; } = IsActive;
}