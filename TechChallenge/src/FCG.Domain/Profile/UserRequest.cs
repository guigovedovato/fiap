namespace FCG.Domain.Profile;

public class UserRequest(string FirstName, string LastName, string Role, string Email, string Password, bool IsActive = true);