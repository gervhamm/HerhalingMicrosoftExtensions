using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddScoped<ServiceB>();
services.AddSingleton<ServiceA>();
services.AddTransient<ServiceC>();

var provider = services.BuildServiceProvider();

using var scope1 = provider.CreateScope();
var serviceB1 = scope1.ServiceProvider.GetRequiredService<ServiceB>();

using var scope2 = provider.CreateScope();
var serviceB2 = scope2.ServiceProvider.GetRequiredService<ServiceB>();

var serviceA1 = provider.GetRequiredService<ServiceA>();
var serviceA2 = provider.GetRequiredService<ServiceA>();

var serviceC1 = provider.GetRequiredService<ServiceC>();
var serviceC2 = provider.GetRequiredService<ServiceC>();
var serviceC3 = provider.GetRequiredService<ServiceC>();

serviceB1.Print("Hello from Service B1");
serviceB2.Print("Hello from Service B2");

