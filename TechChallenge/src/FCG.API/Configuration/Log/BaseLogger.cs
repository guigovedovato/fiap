using Serilog;
using FCG.API.Configuration.Middleware.CorrelationId;

namespace FCG.API.Configuration.Log;

public class BaseLogger
{
    protected readonly Serilog.ILogger _logger;
    protected readonly ICorrelationIdGenerator _correlationId;

    
    public BaseLogger(Serilog.ILogger logger, ICorrelationIdGenerator correlationId)
    {
        _logger = logger;
        _correlationId = correlationId;
    }

    public virtual void LogInformation(string message)
    {
        _logger.Information($"[CorrelationId: {_correlationId.Get()}] {message}");
    }

    public virtual void LogError(string message)
    {
        _logger.Error($"[CorrelationId: {_correlationId.Get()}] {message}");
    }

    public virtual void LogWarning(string message)
    {
        _logger.Warning($"[CorrelationId: {_correlationId.Get()}] {message}");
    }
}