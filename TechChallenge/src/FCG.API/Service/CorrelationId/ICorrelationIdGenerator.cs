namespace FCG.API.Service.CorrelationId;

public interface ICorrelationIdGenerator
{
    public string Get();

    public void Set(string correlationId);
}