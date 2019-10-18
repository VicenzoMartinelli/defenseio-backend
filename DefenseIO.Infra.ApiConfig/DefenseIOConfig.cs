using DefenseIO.Infra.ApiConfig.Database;
using DefenseIO.Infra.ApiConfig.Security;
using DefenseIO.Infra.ApiConfig.ServiceDiscovery;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DefenseIO.Infra.ApiConfig
{
  public static class DefenseIOConfig
  {
    public static void AddDefenseIOServiceConfig<TDBContext>(this IServiceCollection services, IConfiguration configuration) where TDBContext : DbContext
    {
      services.AddServiceDiscovery(configuration.GetServiceConfig());

      services.AddServiceDb<TDBContext>(configuration);

      services.AddAuthenticationSetup(configuration);

      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
    }

    public static void UseDefaultDefenseIOPipeline(IApplicationBuilder app)
    {
      app.UseCors(c =>
      {
        c.AllowAnyHeader();
        c.AllowAnyMethod();
        c.AllowAnyOrigin();
      });

      app.UseAuthentication();

      app.UseMvc();
    }
  }
}
