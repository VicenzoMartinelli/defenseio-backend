using DefenseIO.Domain.Domains.Chatting.Interfaces;
using DefenseIO.Infra.ApiConfig;
using DefenseIO.Services.Chat.Data.Contexts;
using DefenseIO.Services.Chat.Data.Repositories;
using DefenseIO.Services.Chat.Hubs;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DefenseIO.Services.Chat
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
      services.AddDefenseIOServiceConfig<ChatContext>(
        Configuration,
        () =>
        {
          services.AddMediatR(typeof(Startup).Assembly);
          services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
          services.AddSignalR();
        });
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDefaultDefenseIOPipeline(Configuration, () =>
      {
        app.UseSignalR((x) =>
        {
          x.MapHub<ChatHub>("/chat");
        });
      });
    }
  }
}
