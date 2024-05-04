using Microsoft.Extensions.Logging;

namespace HerhalingMicrosoftExtensions;
class ServiceA : IService
{
    private readonly ILogger _logger;
    
    public ServiceA(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger("ServiceA");
        _logger.LogDebug("Service A Created");

    }

    public void Print(string message)
    {
        _logger.LogTrace("Service A Trace: {message}", message);
        _logger.LogDebug("Service A Debug: {message}", message);
        _logger.LogWarning("Service A Warning: {message}", message);
    }
}
