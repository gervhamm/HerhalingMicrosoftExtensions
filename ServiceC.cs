using Microsoft.Extensions.Logging;

namespace HerhalingMicrosoftExtensions;

class ServiceC
{
    private readonly ILogger _logger;

    public ServiceC(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger("ServiceC");
        _logger.LogDebug("Service C Created");

    }

    public void Print(string message)
    {
        _logger.LogTrace("Service C Trace: {message}", message);
        _logger.LogDebug("Service C Debug: {message}", message);
        _logger.LogWarning("Service C Warning: {message}", message);
    }
}
