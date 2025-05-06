using MessagePack;

namespace FCG.Domain.Profile;

[MessagePackObject]
public class UserRequest(string FirstName, string LastName, string Role, string Email, string Password, bool IsActive = true)
{
    [Key(0)]
    public string FirstName { get; set; } = FirstName;

    [Key(1)]
    public string LastName { get; set; } = LastName;

    [Key(2)]
    public string Role { get; set; } = Role;

    [Key(3)]
    public string Email { get; set; } = Email;

    [Key(4)]
    public string Password { get; set; } = Password;

    [Key(5)]
    public bool IsActive { get; set; } = IsActive;
}