namespace Interfaces
{
    public interface ILoggers
    {
        void LogError(string error);
        void LogInformation(string message);
    }
}