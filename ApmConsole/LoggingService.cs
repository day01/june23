namespace ApmConsole;

public class LoggingService
{
    private void LogSth()
    {
        Console.WriteLine($"{Environment.CurrentManagedThreadId} - Start log sth - {DateTime.Now}");
        Thread.Sleep(TimeSpan.FromSeconds(15));
        Console.WriteLine($"{Environment.CurrentManagedThreadId} - End log sth - {DateTime.Now}");
    }
    
    public IAsyncResult LogMeAsync()
    {
        return Task.Run(LogSth);
    }
}
