using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShiftLoggerConsole;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

services.AddSingleton(configuration);
services.AddTransient<Startup>();

var serviceProvider = services.BuildServiceProvider();
var startup = serviceProvider.GetService<Startup>();

startup!.Run();