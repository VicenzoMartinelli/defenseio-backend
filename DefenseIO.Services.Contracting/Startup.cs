using DefenseIO.Infra.ApiConfig;
using DefenseIO.Services.Contracting.Commands.AttendedModality;
using DefenseIO.Services.Contracting.Data.Contexts;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using System.Reflection;

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
        var a = services.RegisterAssemblyPublicNonGenericClasses(Assembly.GetExecutingAssembly())
         .Where(c => c.Name.EndsWith("Repository"));

        a.TypeFilter = (x => x.Name != "IRepository");

        a.AsPublicImplementedInterfaces();

        services.AddScoped<IValidator<UpdateAttendedModalityCommand>, UpdateAttendedModalityCommandValidator>();
        services.AddScoped<IValidator<CreateAttendedModalityCommand>, CreateAttendedModalityCommandValidator>();

        services.AddMediatR(typeof(Startup).Assembly);
      });
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDefaultDefenseIOPipeline(Configuration);
    }
  }
}
