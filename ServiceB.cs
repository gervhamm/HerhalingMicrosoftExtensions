using Microsoft.Extensions.Logging;

namespace HerhalingMicrosoftExtensions;
class ServiceB
{
    private readonly ServiceA _service;

    private readonly ILogger<ServiceB> _logger;
    public ServiceB(ServiceA service, ILogger<ServiceB> logger)
    {
        _logger = logger;
        _logger.LogDebug("Service B Created");
        _service = service;
    }
    public void Print(string message)
    {
        _logger.LogTrace("Service B Trace: {message}", message);
        _logger.LogDebug("Service B Debug: {message}", message);
        _logger.LogWarning("Service B Warning: {message}", message);
    }
}