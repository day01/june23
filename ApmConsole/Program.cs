using System.Net;
using ApmConsole;

public static class Program
{
    public static void Main()
    {
        var srv = new LoggingService();
        var result = srv.LogMeAsync();
        Console.WriteLine("Enter host name to resolve:");
        var hosts = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(hosts))
        {
            return;
        }

        var tasks = new List<Task<IPHostEntry>>();
        foreach (var host in hosts.Split(","))
        {
            var task = Dns.GetHostEntryAsync(host);
            tasks.Add(task);
        }
        
        var taskResults = Task.WhenAll(tasks);

        taskResults.Wait();

        foreach (var res in taskResults.Result)
        {
            Console.WriteLine(res.HostName);
        }

        // while (result.IsCompleted == false)
        // {
        //     Thread.Sleep(TimeSpan.FromSeconds(1));
        //     Console.WriteLine("Waiting for logging service to finish...");
        // }
    }
}