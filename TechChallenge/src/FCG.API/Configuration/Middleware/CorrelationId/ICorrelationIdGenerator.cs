namespace FCG.API.Configuration.Middleware.CorrelationId;

public interface ICorrelationIdGenerator
{
    public string Get();

    public void Set(string correlationId);
}