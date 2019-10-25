using DefenseIO.Domain.Domains.Contracting.Interfaces;
using DefenseIO.Infra.ApiConfig;
using DefenseIO.Services.Contracting.Data.Contexts;
using DefenseIO.Services.Contracting.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DefenseIO.Services.Contracting
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDefenseIOServiceConfig<ContractingContext>(Configuration, () =>
      {
        services.AddScoped<IModalityRepository, ModalityRepository>();
        services.AddScoped<IAttendedModalityRepository, AttendedModalityRepository>();
        services.AddScoped<ISolicitationRepository, SolicitationRepository>();
        services.AddScoped<ISolicitationEvaluationRepository, SolicitationEvaluationRepository>();
      });
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDefaultDefenseIOPipeline(Configuration);
    }
  }
}
