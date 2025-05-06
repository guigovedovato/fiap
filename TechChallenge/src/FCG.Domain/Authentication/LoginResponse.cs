using MessagePack;

namespace FCG.Domain.Authentication;

[MessagePackObject]
public class LoginResponse(int UserName, string Role, string Token, Guid CorrelationId)
{
    [Key(0)]
    public int UserName { get; set; } = UserName;

    [Key(1)]
    public string Role { get; set; } = Role;

    [Key(2)]
    public string Token { get; set; } = Token;

    [Key(3)]
    public Guid CorrelationId { get; set; } = CorrelationId;
}