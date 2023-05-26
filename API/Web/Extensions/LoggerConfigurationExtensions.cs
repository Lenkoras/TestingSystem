using Serilog;

namespace Web.Extensions
{
    public static class LoggerConfigurationExtensions
    {
        private static string FileLogPath = "logs/log.txt";

        public static Serilog.ILogger CreateDefault(this LoggerConfiguration configuration)
        {
            return configuration
                .WriteTo.Console()
                .WriteTo.File(FileLogPath)
                .CreateLogger();
        }
    }
}
