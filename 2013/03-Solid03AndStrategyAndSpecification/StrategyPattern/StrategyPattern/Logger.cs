namespace StrategyPattern
{
    public abstract class Logger
    {
        public abstract void LogMessage(string message);

        public abstract void LogError(string errorMessage);
    }
}
