using DefenseIO.Infra.ApiConfig;
using DefenseIO.Infra.ApiConfig.MassTransit;
using DefenseIO.Services.Contracting.Commands.AttendedModality;
using DefenseIO.Services.Contracting.Consumers;
using DefenseIO.Services.Contracting.Data.Contexts;
using FluentValidation;
using GreenPipes;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

        services.AddMassTransit(x =>
        {
          x.AddConsumer<UpdateProviderDataConsumer>();

          x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
          {
            var baseUri = $"rabbitmq://{Configuration["RabbitMQHost"]}";

            var host = cfg.Host("localhost", "/", hostConfig =>
            {
              hostConfig.Username("guest");
              hostConfig.Password("guest");
            });

            cfg.ReceiveEndpoint(host, "update_provider", ep =>
            {
              ep.UseMessageRetry(r => r.Interval(2, 100));

              ep.ConfigureConsumer<UpdateProviderDataConsumer>(provider);
            });
          }));
        });

        services.AddSingleton<IHostedService, MassTransitApiHostedService>();
      });
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDefaultDefenseIOPipeline(Configuration);
    }
  }
}
