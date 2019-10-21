using DefenseIO.Infra.ApiConfig;
using DefenseIO.Services.Report.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DefenseIO.Services.Report
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
      services.AddDefenseIOServiceConfig<ReportContext>(Configuration);
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDefaultDefenseIOPipeline(Configuration);
    }
  }
}
