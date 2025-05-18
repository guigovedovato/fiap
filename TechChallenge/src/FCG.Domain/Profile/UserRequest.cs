using MessagePack;

namespace FCG.Domain.Profile;

public class UserRequest(string FirstName, string LastName, Role Role, string Email, string Password)
{
    public string FirstName { get; set; } = FirstName;

    public string LastName { get; set; } = LastName;

    public Role Role { get; set; } = Role;

    public string Email { get; set; } = Email;

    public string Password { get; set; } = Password;

    public UserDto ToUserDto() => new()
    {
        FirstName = FirstName,
        LastName = LastName,
        Role = Role,
        Email = Email,
        Password = Password
    };
}