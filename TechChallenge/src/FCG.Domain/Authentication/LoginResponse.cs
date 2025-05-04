namespace FCG.Domain.Authentication;

public class LoginResponse(int UserName, string Role, string Token, Guid CorrelationId);