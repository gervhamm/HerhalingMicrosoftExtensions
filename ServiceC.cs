using Microsoft.Extensions.Logging;

namespace HerhalingMicrosoftExtensions;

class ServiceC
{
    private readonly ILogger<ServiceC> _logger;
    public ServiceC(ILogger<ServiceC> logger)
    {
        _logger = logger;
    }
    public void Print(string message)
    {
        _logger.LogTrace("Service C Trace: {message}", message);
        _logger.LogDebug("Service C Debug: {message}", message);
        _logger.LogWarning("Service C Warning: {message}", message);
    }
}
