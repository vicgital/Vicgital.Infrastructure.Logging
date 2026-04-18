
using Vicgital.Infrastructure.Logging.Configuration.Extensions;

Serilog.LoggerConfiguration config = Vicgital.Infrastructure.Logging.Configuration.LoggerConfigurationBuilder.BuildDefault( Serilog.Events.LogEventLevel.Information);

config.EnrichWithRedacter(["password"]);

config.WriteToFile($"C:\\temp\\log_{DateTime.UtcNow.ToFileTimeUtc()}.txt", Serilog.RollingInterval.Day);

Serilog.ILogger logger = config.CreateLogger();

logger.Information("Hello World");

logger.Information("User logged in with username: {Username} and password: {Password}", "testuser", "secretpassword");

try
{

	// log random information logs 
	for (int i = 0; i < 10; i++)
	{
		logger.Information("Random log message {Index}", i);    
	}

	// log random warning logs 
	for (int i = 0; i < 5; i++)
	{ 
		logger.Warning("Random warning message {Index}", i);
    }

    throw new Exception("Test Exception");
}
catch (Exception ex)
{
	logger.Error(ex, "Test Error: message: {Message}", ex.Message);
}


