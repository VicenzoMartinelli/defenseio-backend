using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace DefenseIO.Infra.ApiConfig.Swagger
{
  public static class SwaggerMiddleware
  {
    public static IApplicationBuilder UseDefaultSwagger(this IApplicationBuilder app, IConfiguration configuration)
    {
      var serviceName = configuration.GetValue<string>("ServiceConfig:displayName");

      app
        .UseSwagger()
        .UseSwaggerUI(s =>
        {
          s.SwaggerEndpoint("/swagger/v1/swagger.json", $"DefenseIO | {serviceName}");
          s.DisplayRequestDuration();
          s.EnableValidator();

          s.RoutePrefix = string.Empty;
          s.DocumentTitle = $"DefenseIO {serviceName} - Restful Api";
        });

      return app;
    }
  }
}
