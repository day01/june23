using AspEbPattern.Services;

namespace AspEbPattern.HostedServices;

public class EventBasePatternService(ITaskQueue taskQueue, ILogger<EventBasePatternService> logger)
    : BackgroundService
{
    private readonly ILogger _logger = logger;

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("{HostedServiceName} is starting", nameof(EventBasePatternService));
        return Loop(stoppingToken);
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("{HostedServiceName} is stopping", nameof(EventBasePatternService));

        return base.StopAsync(cancellationToken);
    }

    private async Task Loop(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var eventToProcess = await taskQueue.Dequeue(cancellationToken);

                eventToProcess(cancellationToken);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    e,
                    "Sth goes wrong in {HostedServiceName}",
                    nameof(EventBasePatternService));
                break;
                
                // { message: "Sth goes wrong in EventBasePatternService", exception: "System.Exception", hostedServiceName="EventBasePatternService" }
            }
        }
    }
}