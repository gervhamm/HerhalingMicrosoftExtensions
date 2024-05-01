using Microsoft.Extensions.Logging;

namespace HerhalingMicrosoftExtensions;
class ServiceA
{
    private readonly ILogger<ServiceA> _logger;
    public ServiceA(ILogger<ServiceA> logger)
    {
        _logger = logger;
    }
    public void Print(string message)
    {
        _logger.LogTrace("Service A Trace: {message}", message);
        _logger.LogDebug("Service A Debug: {message}", message);
        _logger.LogWarning("Service A Warning: {message}", message);
    }
}
