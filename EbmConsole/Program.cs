using EbmConsole;

Console.WriteLine("Hello, World!");

var srv = new ExampleService();

srv.LogCompleted += (sender, args) => Console.WriteLine("Log completed");
srv.BeginLog();

var hosts = Console.ReadLine();
if (string.IsNullOrWhiteSpace(hosts))
{
    return;
}

var dnsResolver = new DnsResolver();
dnsResolver.resolved += (sender, eventArgs) =>
{
    Console.WriteLine($"{sender.GetType()} - {eventArgs.HostName} - {eventArgs.IpAddress}");
};

foreach (var host in hosts.Split(","))
{
    dnsResolver.Resolve(host);
}

Thread.Sleep(TimeSpan.FromSeconds(10));

Console.WriteLine("Example");