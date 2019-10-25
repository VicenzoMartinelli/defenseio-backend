using DefenseIO.Domain.Domains.Chatting.Interfaces;
using DefenseIO.Infra.ApiConfig;
using DefenseIO.Services.Chat.Data.Contexts;
using DefenseIO.Services.Chat.Data.Repositories;
using DefenseIO.Services.Chat.Hubs;
using DefenseIO.Services.Chat.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
          services.AddScoped<IChatMessageRepository, ChatMessageRepository>();
          services.AddScoped<ChatService>();
          services.AddSignalR();
        });
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseDefaultDefenseIOPipeline(Configuration, () =>
      {
        app.UseSignalR((x) =>
        {
          x.MapHub<ChatHub>("chat");
        });
      });
    }
  }
}
