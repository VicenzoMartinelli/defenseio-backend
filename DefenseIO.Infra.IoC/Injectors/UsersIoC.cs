using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DefenseIO.Infra.IoC.Injectors
{
  public static class UsersIoC
  {
    public static void AddUsersIoC(this IServiceCollection services)
    {
      services.AddScoped<IRequestHandler<>>
    }
  }
}
