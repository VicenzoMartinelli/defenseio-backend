using Consul;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DefenseIO.Infra.ApiConfig.ServiceDiscovery
{
  public static class ServiceDiscoveryExtensions
  {
    public static IServiceCollection AddServiceDiscovery(this IServiceCollection services, ServiceConfig serviceConfig)
    {
      if (serviceConfig == null)
      {
        throw new ArgumentNullException(nameof(serviceConfig));
      }

      var consulClient = new ConsulClient(config =>
      {
        config.Address = serviceConfig.ServiceDiscoveryAddress;
      });

      services.AddSingleton(serviceConfig);
      services.AddHostedService<ServiceDiscoveryHostedService>();
      services.AddSingleton<IConsulClient, ConsulClient>(p => consulClient);

      return services;
    }
  }
}
