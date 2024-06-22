using System.ComponentModel;

namespace EbmConsole;

public class ExampleService
{
    public event EventHandler LogCompleted;

    public void BeginLog()
    {
        var worker = new BackgroundWorker();
        worker.DoWork += (sender, args) => LogMe();
        worker.RunWorkerCompleted += (sender, args) => LogCompleted?.Invoke(this, EventArgs.Empty);
    }
    
    
    private string LogMe()
    {
        Task.Delay(TimeSpan.FromSeconds(10));
        return "Log completed";
    }
}