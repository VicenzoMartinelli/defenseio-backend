using DefenseIO.Domain.Core;
using DefenseIO.Infra.IoC.Injectors;
using Microsoft.Extensions.DependencyInjection;

namespace DefenseIO.Infra.IoC
{
  public static class InjectorBootstrap
  {
    public static void AddRegisterLegadoPortalPacienteServices(this IServiceCollection services)
    {
      services.AddScoped<NotificationContext>();

      services.AddUsersIoC();
    }
  }
}
