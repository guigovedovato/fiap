namespace FCG.Domain.Profile;

public class UserDto
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Role { get; set; }
    public bool IsActive { get; set; }
    public required string Email { get; set; }
    public string Password { get; set; } = string.Empty;

    public UserResponse ToUserResponse() => new(Id, CreatedAt, UpdatedAt, FirstName, LastName, Role, Email, IsActive);
}