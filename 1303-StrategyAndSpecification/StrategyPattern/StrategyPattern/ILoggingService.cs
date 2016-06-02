namespace StrategyPattern
{
    public interface ILoggingService
    {
        void LogMessage(LoggingStrategy loggingStrategy, string message);

        void LogError(LoggingStrategy loggingStrategy, string errorMessage);
    }
}
