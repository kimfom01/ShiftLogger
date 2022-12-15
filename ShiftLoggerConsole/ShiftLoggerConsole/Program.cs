using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShiftLoggerConsole;
using ShiftLoggerConsole.Services;
using ShiftLoggerConsole.UI;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();

services.AddSingleton(configuration);
services.AddSingleton<IStartup, Startup>();
services.AddSingleton<HttpClient>();
services.AddTransient<IApiConnectionService, ApiConnectionService>();
services.AddTransient<IUserInteraction, UserInteraction>();

var serviceProvider = services.BuildServiceProvider();
var startup = serviceProvider.GetService<IStartup>();

await startup!.Run();