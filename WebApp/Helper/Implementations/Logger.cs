using Interfaces;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace Implementations
{
    public class Logger : ILoggers
    {
        public static void LogInitialize(IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                  .ReadFrom.Configuration(configuration)
                  .CreateLogger();
        }

        public void LogError(string error)
        {
            Log.Write(LogEventLevel.Error, error);
        }

        public void LogInformation(string message)
        {
            Log.Write(LogEventLevel.Information, message);
        }
    }
}