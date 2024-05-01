using HerhalingMicrosoftExtensions;
using HerhalingMicrosoftExtensions.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = new ConfigurationBuilder()
    .AddInMemoryCollection(new Dictionary<string, string?>
    {
        ["Name"] = "Gert"
    })
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile("appsettings.Development.json", optional: true)
    //.AddJsonFile("appsettings.Production.json", optional: true)
    .AddEnvironmentVariables();

var configuration = builder.Build();

var logLevel = configuration["Logging:LogLevel:HerhalingMicrosoftExtensions"];
Console.WriteLine($"LogLevel: {logLevel}");

var herhalingMicrosoftExtensions = new HerhalingMicrosoftExtensionsConfiguration();
configuration.Bind("HerhalingMicrosoftExtensions", herhalingMicrosoftExtensions);

var section = configuration.GetSection("HerhalingMicrosoftExtensions");

var name = section["Name"];
var connectionString = configuration["HerhalingMicrosoftExtensions:ConnectionString"];

#region Logging

/*var factory = LoggerFactory.Create(builder =>
{
    //builder.SetMinimumLevel(LogLevel.Trace);
    builder.AddConsole();
    builder.AddFilter("HerhalingMicrosoftExtensions.ServiceA", LogLevel.Trace);
    builder.AddFilter("HerhalingMicrosoftExtensions.ServiceB", LogLevel.Debug);
    builder.AddFilter("HerhalingMicrosoftExtensions.ServiceC", LogLevel.Debug);
});

var logger = factory.CreateLogger("Default");
logger.LogTrace("Log Trace: Service A");
logger.LogDebug("Log Debug: Service B and C");
logger.LogInformation("Log Information");
logger.LogWarning("Log Warning: Other");
logger.LogError("Log Error");
logger.LogCritical("Log Critical");

logger.LogWarning("Configuration Name: {name}", herhalingMicrosoftExtensions.Name);
logger.LogWarning("Configuration ConnectionString: {connectionString}", herhalingMicrosoftExtensions.ConnectionString);*/

#endregion

var services = new ServiceCollection();
// Manually register serviceB with serviceA (not necessary in this case, when using interfaces)
services.AddScoped(provider =>
{
    var service = provider.GetRequiredService<ServiceA>();
    var logger = provider.GetRequiredService<ILogger<ServiceB>>();
    return new ServiceB(service, logger);
});
services.AddSingleton<ServiceA>();
services.AddTransient<ServiceC>();
services.AddLogging(builder =>
{
    builder.AddConsole();
});

var provider = services.BuildServiceProvider(validateScopes: true);

using (var scope1 = provider.CreateScope())
{
    var serviceB1 = scope1.ServiceProvider.GetRequiredService<ServiceB>();
    serviceB1.Print("Hello from Service B1");
};

using var scope2 = provider.CreateScope();
var serviceB2 = scope2.ServiceProvider.GetRequiredService<ServiceB>();

var serviceA1 = provider.GetRequiredService<ServiceA>();
var serviceA2 = provider.GetRequiredService<ServiceA>();

var serviceC1 = provider.GetRequiredService<ServiceC>();
var serviceC2 = provider.GetRequiredService<ServiceC>();
var serviceC3 = provider.GetRequiredService<ServiceC>();

serviceB2.Print("Hello from Service B2");

serviceA1.Print("Hello from Service A1");
serviceA2.Print("Hello from Service A2");

serviceC1.Print("Hello from Service C1");
serviceC2.Print("Hello from Service C2");
serviceC3.Print("Hello from Service C3");




