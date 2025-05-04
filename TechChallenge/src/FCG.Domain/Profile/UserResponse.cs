namespace FCG.Domain.Profile;

public class UserResponse(int Id, DateTime CreatedAt, DateTime UpdatedAt, string FirstName, string LastName, string Role, string Email, bool IsActive);