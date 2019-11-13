using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace DefenseIO.Infra.ApiConfig.MassTransit
{
  public class MassTransitApiHostedService : IHostedService
  {
    private readonly IBusControl _bus;

    public MassTransitApiHostedService(IBusControl bus, ILoggerFactory loggerFactory)
    {
      _bus = bus;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
      await _bus.StartAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
      await _bus.StopAsync(cancellationToken).ConfigureAwait(false);
    }
  }
}
