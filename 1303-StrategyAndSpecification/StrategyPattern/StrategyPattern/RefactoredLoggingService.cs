using System;
using System.Collections.Generic;

namespace StrategyPattern
{
    public class RefactoredLoggingService : ILoggingService
    {
        private readonly Dictionary<LoggingStrategy, Lazy<Logger>> strategies = new Dictionary<LoggingStrategy, Lazy<Logger>>();

        public RefactoredLoggingService()
        {
            this.DefineStrategies();
        }

        public void LogMessage(LoggingStrategy loggingStrategy, string message)
        {
            this.strategies[loggingStrategy].Value.LogMessage(message);
        }

        public void LogError(LoggingStrategy loggingStrategy, string errorMessage)
        {
            this.strategies[loggingStrategy].Value.LogError(errorMessage);
        }

        private void DefineStrategies()
        {
            this.strategies.Add(LoggingStrategy.Event, new Lazy<Logger>(() => new EventLogger()));
            this.strategies.Add(LoggingStrategy.Repository, new Lazy<Logger>(() => new RepositoryLogger()));
            this.strategies.Add(LoggingStrategy.Trace, new Lazy<Logger>(() => new TraceLogger()));
        }
    }
}
