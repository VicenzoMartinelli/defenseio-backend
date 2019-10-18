using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DefenseIO.Infra.ApiConfig.Database
{
  public static class DataConfig
  {
    public static IServiceCollection AddServiceDb<TDBContext>(this IServiceCollection services, IConfiguration config) where TDBContext : DbContext
    {
      return services.AddDbContext<TDBContext>((options) => options.UseNpgsql(config.GetConnectionString("ServiceDb")));
    }
  }
}
