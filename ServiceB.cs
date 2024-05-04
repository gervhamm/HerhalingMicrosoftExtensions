using Microsoft.Extensions.Logging;

namespace HerhalingMicrosoftExtensions;
class ServiceB
{
    private readonly IService _service;

    private readonly ILogger _logger;
    public ServiceB(IService service, ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger("ServiceB");
        _logger.LogDebug("Service B Created");
        _service = service;
    }
    public void Print(string message)
    {
        _service.Print(message);
    }
}