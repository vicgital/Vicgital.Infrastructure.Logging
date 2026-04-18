
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Vicgital.Infrastructure.Logging.Configuration.Extensions;
using Vicgital.Infrastructure.Logging.Extensions;

Serilog.LoggerConfiguration config = Vicgital.Infrastructure.Logging.Configuration.LoggerConfigurationBuilder.BuildDefault(Serilog.Events.LogEventLevel.Information);

config.EnrichWithRedacter(["password"]);

config.WriteToFile($"C:\\temp\\log_{DateTime.UtcNow.ToFileTimeUtc()}.txt", Serilog.RollingInterval.Day);

IServiceCollection services = new ServiceCollection();

services.AddSerilogLogging(config.CreateLogger());

var provider = services.BuildServiceProvider();
var _logger = provider.GetRequiredService<ILogger<Program>>();


_logger.LogInformation("Hello World");

_logger.LogInformation("User logged in with username: {Username} and password: {Password}", "testuser", "secretpassword");

try
{

    // log random information logs 
    for (int i = 0; i < 10; i++)
    {
        _logger.LogInformation("Random log message {Index}", i);
    }

    // log random warning logs 
    for (int i = 0; i < 5; i++)
    {
        _logger.LogWarning("Random warning message {Index}", i);
    }

    throw new Exception("Test Exception");
}
catch (Exception ex)
{
    _logger.LogError(ex, "Test Error: message: {Message}", ex.Message);
}


