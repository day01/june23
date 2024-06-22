using System.ComponentModel;
using System.Net;

namespace EbmConsole;

public class DnsHostResolvedEventArgs : EventArgs
{
    public string HostName { get; }
    public string IpAddress { get; }

    public DnsHostResolvedEventArgs(string hostName, string ipAddress)
    {
        HostName = hostName;
        IpAddress = ipAddress;
    }
}

public class DnsResolver
{
    public event EventHandler<DnsHostResolvedEventArgs> resolved;

    public void Resolve(string hostname)
    {
        var worker = new BackgroundWorker();
        worker.DoWork += (sender, args) =>
        {
            var hostEntry = Dns.GetHostEntry(hostname);
            args.Result = hostEntry;
        };
        
        worker.RunWorkerCompleted += (sender, args) =>
        {
            var hostEntry = (IPHostEntry?)args.Result;
            foreach (var ipAddress in hostEntry.AddressList)
            {
                resolved.Invoke(this, new DnsHostResolvedEventArgs(hostEntry.HostName, ipAddress.ToString()));
            }
        };
        
        worker.RunWorkerAsync();
        
    }
}